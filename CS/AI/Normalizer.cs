using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using CS.IO;

namespace CS.AI
{
    public class Normalizer
    {
        public struct NormS
        {
            public int index;
            public string text;
            public float offset;
            public float bias;
        }

        public enum BinDivision
        {
            distinct,
            linear,
            logarithmic
        }

        public struct NormInfo
        {
            public NormInfo(BinDivision division, int bins = 1)
            {
                this.division = division;
                this.bins = bins;
            }
            public BinDivision division;
            public int bins;
        }

        Random randTS;

        public string[] columns;
        public string[][] rows;
        internal float tsRatio;
        internal bool[] ts;
        public int inputCount, outputCount;
        public float[][] inputs;
        public float[][] outputs;

        public NormS[] norms;
        public bool[] isOutput;

        public Dictionary<string, List<NormS>> inputMap = new Dictionary<string, List<NormS>>();
        public Dictionary<string, List<NormS>> outputMap = new Dictionary<string, List<NormS>>();

        public bool LoadData(string fileName, bool loadRows = true, bool hasHeader = true)
        {
            string file = FileHelper.ReadFile(fileName);

            if (file == null) return false;

            List<string[]> lRows = new List<string[]>();

            int pos = 0;
            bool eof = false;

            if (hasHeader)
            {
                columns = FileHelper.GetCsvValues(file, ref pos, out eof);
            }

            if (loadRows)
            {
                while (!eof)
                {
                    string[] csv = FileHelper.GetCsvValues(file, ref pos, out eof);

                    if (columns == null)
                        columns = new string[csv.Length];

                    if (csv.Length == 0) break;
                    lRows.Add(csv);
                }
            }

            rows = lRows.ToArray();

            return true;
        }

        public void Norm(Dictionary<string, NormInfo> normInfo = null)
        {
            List<NormS> lNorms = new List<NormS>();

            for (int i = 0; i < columns.Length; i++)
            {
                Dictionary<string, int> distinctValues = new Dictionary<string, int>();

                float min = float.MaxValue;
                float max = float.MinValue;

                bool numeric = true;

                for (int j = 0; j < rows.Length; j++)
                {

                    if (!distinctValues.ContainsKey(rows[j][i]))
                    {
                        distinctValues[rows[j][i]] = 0;
                    }
                    distinctValues[rows[j][i]]++;

                    DateTime datetime;
                    float value;
                    if (float.TryParse(rows[j][i], out value))
                    {
                        if (value < min) min = value;
                        if (value > max) max = value;
                    }
                    else if (DateTime.TryParse(rows[j][i], out datetime))
                    {
                        value = (float)(datetime.Ticks / 10000000) / 86400f;

                        if (value < min) min = value;
                        if (value > max) max = value;
                    }
                    else
                    {
                        numeric = false;
                    }
                }

                float lo = 0.25F;
                float hi = 0.75F;

                if (normInfo != null && normInfo.ContainsKey(columns[i]))
                {
                    switch (normInfo[columns[i]].division)
                    {
                        case BinDivision.distinct:

                            foreach (string value in distinctValues.Keys)
                            {
                                NormS norm = new NormS();
                                norm.index = i;
                                norm.text = value;

                                lNorms.Add(norm);
                            }

                            break;
                        case BinDivision.linear:
                            {

                                int bands = normInfo[columns[i]].bins;

                                float step = (max - min) / bands;
                                for (int band = 0; band < bands; band++)
                                {
                                    float from = min + band * step;
                                    float to = from + step;

                                    NormS norm = new NormS();
                                    norm.index = i;
                                    norm.bias = (hi - lo) / (to - from);
                                    norm.offset = lo / norm.bias - from;

                                    lNorms.Add(norm);
                                }
                            }
                            break;

                        case BinDivision.logarithmic:
                            {
                                float min_ = min == 0.0f ? 1.0f : min;
                                int bands = normInfo[columns[i]].bins;

                                float step = (float)Math.Pow(max / min_, 1.0f / bands);
                                for (int band = 0; band < bands; band++)
                                {
                                    float from = band == 0 ? min : min_ * (float)Math.Pow(step, band);
                                    float to = min_ * (float)Math.Pow(step, band + 1);

                                    NormS norm = new NormS();
                                    norm.index = i;
                                    norm.bias = (hi - lo) / (to - from);
                                    norm.offset = lo / norm.bias - from;

                                    lNorms.Add(norm);
                                }
                            }
                            break;
                    }

                }
                else
                {
                    if (numeric)
                    {
                        if (min >= 0 & max <= 1) //TODO
                        {
                            NormS norm = new NormS();
                            norm.index = i;
                            norm.bias = 1f;
                            norm.offset = 0f;
                            lNorms.Add(norm);
                        }
                        else
                        {
                            float min_ = min == 0.0f ? 1.0f : min;
                            int bands = (int)Math.Ceiling(Math.Log10(max / min_) * 2);

                            float step = (float)Math.Pow(max / min_, 1.0f / bands);
                            for (int band = 0; band < bands; band++)
                            {
                                float from = band == 0 ? min : min_ * (float)Math.Pow(step, band);
                                float to = min_ * (float)Math.Pow(step, band + 1);

                                NormS norm = new NormS();
                                norm.index = i;
                                norm.bias = (hi - lo) / (to - from);
                                norm.offset = lo / norm.bias - from;

                                lNorms.Add(norm);
                            }
                        }
                    }
                    else
                    {
                        foreach (string value in distinctValues.Keys)
                        {
                            NormS norm = new NormS();
                            norm.index = i;
                            norm.text = value;

                            lNorms.Add(norm);
                        }
                    }
                }

            }

            norms = lNorms.ToArray();
        }

        public void WriteNorm(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            for (int i = 0; i < norms.Length; i++)
            {
                writer.WriteLine("{0},{1},{2},{3}", norms[i].index, norms[i].offset, norms[i].bias, norms[i].text);
            }

            writer.Close();
        }

        public void ReadNorm(string fileName)
        {

            string file = FileHelper.ReadFile(fileName);

            List<NormS> lNorms = new List<NormS>();

            int pos = 0;
            bool eof = false;

            while (!eof)
            {
                string[] csv = FileHelper.GetCsvValues(file, ref pos, out eof);

                if (csv == null) break;

                NormS norm = new NormS();
                norm.index = int.Parse(csv[0]);
                norm.offset = float.Parse(csv[1]);
                norm.bias = float.Parse(csv[2]);
                norm.text = csv.Length <= 3 ? null : (csv[3] == "" ? null : csv[3]);

                lNorms.Add(norm);
            }

            norms = lNorms.ToArray();
        }

        public void CreateIO(params string[] outputColumns)
        {
            inputCount = 0;
            outputCount = 0;

            isOutput = new bool[norms.Length];
            for (int i = 0; i < norms.Length; i++)
            {
                if (outputColumns.Contains(columns[norms[i].index]))
                {
                    if (!outputMap.ContainsKey(columns[norms[i].index])) outputMap[columns[norms[i].index]] = new List<NormS>();
                    NormS outputNorm = new NormS();
                    outputNorm.index = outputCount;
                    outputNorm.text = norms[i].text;
                    outputNorm.offset = norms[i].offset;
                    outputNorm.bias = norms[i].bias;
                    outputMap[columns[norms[i].index]].Add(outputNorm);

                    outputCount++;
                    isOutput[i] = true;
                }
                else
                {
                    if (!inputMap.ContainsKey(columns[norms[i].index])) inputMap[columns[norms[i].index]] = new List<NormS>();
                    NormS inputNorm = new NormS();
                    inputNorm.index = inputCount;
                    inputNorm.text = norms[i].text;
                    inputNorm.offset = norms[i].offset;
                    inputNorm.bias = norms[i].bias;
                    inputMap[columns[norms[i].index]].Add(inputNorm);

                    inputCount++;
                    isOutput[i] = false;
                }
            }

            inputs = new float[rows.Length][];
            outputs = new float[rows.Length][];
            ts = new bool[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                inputs[i] = new float[inputCount];
                outputs[i] = new float[outputCount];
                ts[i] = true;

                int ii = 0;
                int io = 0;

                for (int j = 0; j < norms.Length; j++)
                {
                    string cell = rows[i][norms[j].index];

                    float value;

                    if (norms[j].text == null)
                    {
                        float cell_value = 0f;
                        DateTime datetime;

                        if (float.TryParse(cell, out cell_value))
                        {

                        }
                        else if (DateTime.TryParse(cell, out datetime))
                        {
                            cell_value = (float)(datetime.Ticks / 10000000) / 86400f;
                        }

                        value = Math.Min(Math.Max((cell_value + norms[j].offset) * norms[j].bias, 0.0f), 1.0f);
                    }
                    else
                    {
                        value = cell == norms[j].text ? 1.0f : 0.0f;
                    }

                    if (isOutput[j])
                    {
                        outputs[i][io] = value;
                        io++;
                    }
                    else
                    {
                        inputs[i][ii] = value;
                        ii++;
                    }
                }
            }
        }

        public void SplitIO(int split)
        {
            inputCount = 0;
            outputCount = 0;

            isOutput = new bool[norms.Length];
            for (int i = 0; i < norms.Length; i++)
            {
                if (i < split)
                {
                    inputCount++;
                    isOutput[i] = false;
                }
                else
                {
                    outputCount++;
                    isOutput[i] = true;
                }
            }

            inputs = new float[rows.Length][];
            outputs = new float[rows.Length][];
            ts = new bool[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                inputs[i] = new float[inputCount];
                outputs[i] = new float[outputCount];
                ts[i] = true;

                int ii = 0;
                int io = 0;

                for (int j = 0; j < norms.Length; j++)
                {
                    string cell = rows[i][norms[j].index];

                    float value;

                    if (norms[j].text == null)
                    {
                        float cell_value = 0f;
                        DateTime datetime;

                        if (float.TryParse(cell, out cell_value))
                        {

                        }
                        else if (DateTime.TryParse(cell, out datetime))
                        {
                            cell_value = (float)(datetime.Ticks / 10000000) / 86400f;
                        }

                        value = Math.Min(Math.Max((cell_value + norms[j].offset) * norms[j].bias, 0.0f), 1.0f);
                    }
                    else
                    {
                        value = cell == norms[j].text ? 1.0f : 0.0f;
                    }

                    if (isOutput[j])
                    {
                        outputs[i][io] = value;
                        io++;
                    }
                    else
                    {
                        inputs[i][ii] = value;
                        ii++;
                    }
                }
            }
        }

        public void SetTSRatio(float tsRatio, int seed = 0)
        {
            if (seed == 0)
                randTS = new Random();
            else
                randTS = new Random(seed);

            for (int i = 0; i < inputs.Length; i++)
            {
                ts[i] = randTS.NextDouble() / tsRatio < 1.0f;
            }
            this.tsRatio = tsRatio;
        }

        public void SetTS(int ix)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                ts[i] = i < ix;
            }
        }

    }
}
