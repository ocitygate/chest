using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using CS.IO;
using System.Collections;

namespace CS.AI
{
    public class NeuralNetwork
    {
        public delegate void CheckPoint();

        Random rand;

        Normalizer normalizer;

        internal int[] neuronCount;
        internal float[][,] weights;
        float[][] values;
        float[][] deltas;
        float[][,] lastadjs;

        public NeuralNetwork(Normalizer normalizer)
        {
            this.normalizer = normalizer;
        }

        public static float NextGaussian(Random r, float mu = 0, float sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return (float)rand_normal;
        }

        public void InitNN(bool initWeights, int seed = 0, params int[] hiddenCount)
        {
            if (seed == 0)
                rand = new Random();
            else
                rand = new Random(seed);

            neuronCount = new int[hiddenCount.Length + 2];
            neuronCount[0] = normalizer.inputCount;
            hiddenCount.CopyTo(neuronCount, 1);
            neuronCount[neuronCount.Length - 1] = normalizer.outputCount;

            weights = new float[neuronCount.Length][,];
            for (int i = 1; i < neuronCount.Length; i++) //layers
            {
                weights[i] = new float[neuronCount[i], neuronCount[i - 1] + 1];
                if (initWeights)
                {
                    for (int j = 0; j < neuronCount[i]; j++) //neuron
                    {
                        for (int k = 0; k < neuronCount[i - 1] + 1; k++) //input
                        {
                            weights[i][j, k] = (float)(NextGaussian(rand) * Math.Sqrt(2.0 / (neuronCount[i - 1] + 1)));
                        }
                    }
                }
            }

            values = new float[neuronCount.Length][];
            for (int i = 0; i < neuronCount.Length; i++) //layers
            {
                values[i] = new float[neuronCount[i] + 1];
                values[i][neuronCount[i]] = 1.0f;
            }

            deltas = new float[neuronCount.Length][];
            for (int i = 1; i < neuronCount.Length - 1; i++) //layers
            {
                deltas[i] = new float[neuronCount[i] + 1];
            }

            lastadjs = new float[neuronCount.Length][,];
            for (int i = 1; i < neuronCount.Length; i++) //layers
            {
                lastadjs[i] = new float[neuronCount[i], neuronCount[i - 1] + 1];
            }
        }

        public void InitNN(params int[] hiddenCount)
        {
            InitNN(true, 0, hiddenCount);
        }

        public void ReadInit(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            List<int> nodes = new List<int>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                nodes.Add(int.Parse(line));
            }
            InitNN(false, 0, nodes.ToArray());
        }

        public void WriteInit(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            for(int i = 1; i < neuronCount.Length - 1; i++)
            {
                file.WriteLine(neuronCount[i]);
            }
            file.Close();
        }


        public void ReadNN(string fileName)
        {
            StreamReader file = new StreamReader(fileName);

            for (int i = 1; i < neuronCount.Length; i++) //layer
            {
                for (int j = 0; j < neuronCount[i]; j++) //out
                {
                    for (int k = 0; k < neuronCount[i - 1] + 1; k++) //in
                    {
                        weights[i][j, k] = float.Parse(file.ReadLine());
                    }
                }
            }
        }

        public void WriteNN(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);

            for (int i = 1; i < neuronCount.Length; i++) //layer
            {
                for (int j = 0; j < neuronCount[i]; j++) //neuron
                {
                    for (int k = 0; k < neuronCount[i - 1] + 1; k++) //input
                    {
                        file.WriteLine(weights[i][j, k]);
                    }
                }
            }

            file.Close();
        }

        void TeachNN(float lrate, float momentum)
        {
            for (int i = 0; i < normalizer.inputs.Length; i++)
            {
                if (normalizer.ts[i])
                {
                    Compute(normalizer.inputs[i]);
                    BackProp(normalizer.outputs[i], lrate, momentum);
                }
            }
        }

        public float Run(int iterations, int seconds, float lrate, float momentum, int checkerror, float min_reduction, CheckPoint checkPoint = null, string saveas = null)
        {
            DateTime finish = DateTime.Now.AddSeconds(seconds);

            float lasterror = float.MaxValue;
            float error = GetError();

            float min_error = float.MaxValue;

            for (int i = 0; (iterations == 0 || i < iterations) & (seconds == 0 || DateTime.Now < finish); i++)
            {
                if (checkerror == 0 || i % checkerror == 0)
                {
                    if (checkPoint != null) checkPoint();

                    error = GetError();

                    if (i > 0) Console.WriteLine();

                    Console.WriteLine("Error: {0}", error);
                    if (error < min_error)
                    {
                        if (saveas != null)
                        {
                            Console.WriteLine("Saving");
                            this.WriteNN(saveas);
                        }

                        min_error = error;
                    }

                    if (lasterror - error < min_reduction)
                        return lasterror;
                    
                    lasterror = error;

                    Console.Write("Interation: ");
                }

                Console.Write("{0} ", i);

                TeachNN(lrate, momentum);
            }
            Console.WriteLine();

            error = GetError();

            Console.WriteLine("Error: {0} ", GetError());

            return saveas == null ? error : min_error;
        }

        public float[] Compute(float[] input)
        {
            input.CopyTo(values[0], 0);

            for (int i = 1; i < neuronCount.Length; i++) //layer
            {
                for (int j = 0; j < neuronCount[i]; j++) //out
                {
                    float value = 0.0f;
                    for (int k = 0; k < neuronCount[i - 1] + 1; k++) //in
                    {
                        value += values[i - 1][k] * weights[i][j, k];
                    }
                    values[i][j] = 1.0f / (1.0f + (float)Math.Exp(-value));
                }
            }

            return values[neuronCount.Length - 1];
        }

        public float[] InWeights()
        {
            float[] inWeights = new float[neuronCount[0]];

            for (int k = 0; k < neuronCount[0]; k++) //in
            {
                inWeights[k] = 0f;
                for (int j = 0; j < neuronCount[1]; j++) //out
                {
                    inWeights[k] +=  (float)Math.Pow(weights[1][j, k], 2);
                }
            }

            return inWeights;
        }

        public string[] Compute(params string[] args)
        {
            float[] input = new float[normalizer.inputCount];

            foreach(string arg in args)
            {
                string[] arg_s = arg.Split(new char[] { '=' }, 2);
                string column;
                string value;
                if (arg_s.Length < 2)
                {
                    column = arg_s[0];
                    value = "1";
                }
                else
                {
                    column = arg_s[0];
                    value = arg_s[1];
                }

                if (normalizer.inputMap.ContainsKey(column))
                {
                    foreach (Normalizer.NormS norm in normalizer.inputMap[column])
                    {
                        float cell_value = 0f;
                        DateTime datetime;

                        if (DateTime.TryParse(value, out datetime))
                        {
                            cell_value = (float)(datetime.Ticks / 10000000) / 86400f;
                        }
                        else if (float.TryParse(value, out cell_value))
                        {

                        }

                        if (norm.text == null)
                        {
                            input[norm.index] = Math.Min(Math.Max((cell_value + norm.offset) * norm.bias, 0.0f), 1.0f);
                        }
                        else
                        {
                            input[norm.index] = norm.text == value ? 1.0f : 0.0f;
                        }
                    }
                }
            }

            float[] output = Compute(input);

            List<string> normOutput = new List<string>();
            //string[] normOutput = new string[normalizer.outputMap.Count];

            foreach (string key in normalizer.outputMap.Keys)
            {
                if (normalizer.outputMap[key][0].text == null)
                {
                    float t = 0f;
                    float c = 0f;

                    foreach (Normalizer.NormS norm in normalizer.outputMap[key])
                    {
                        float x = output[norm.index];

                        float g = x * (1 - x);

                        t += g * (x / norm.bias - norm.offset);
                        c += g;

                    }

                    normOutput.Add(key + "=" + (t / c));
                }
                else
                {
                    foreach (Normalizer.NormS norm in normalizer.outputMap[key])
                    {
                        float x = output[norm.index];

                        normOutput.Add(key + "." + norm.text + "=" + x);

                    }
                }

            }

            return normOutput.ToArray();
        }

        public float GetError(bool all = false)
        {
            /*
            float error = 0.0f;
            float count = 0;
            for (int i = 0; i < normalizer.inputs.Length; i++)
            {
                if (!normalizer.ts[i])
                {
                    count++;

                    float[] output = Compute(normalizer.inputs[i]);

                    foreach (string key in normalizer.outputMap.Keys)
                    {
                        Normalizer.normS norm = new Normalizer.normS();
                        float diff;

                        diff = float.MaxValue;
                        foreach (Normalizer.normS this_norm in normalizer.outputMap[key])
                        {
                            float this_diff = Math.Abs(0.5f - output[this_norm.ix]);
                            if (this_diff < diff)
                            {
                                norm = this_norm;
                                diff = this_diff;
                            }
                        }
                        float output_n = (output[norm.ix] / norm.bias - norm.offset);

                        diff = float.MaxValue;
                        foreach (Normalizer.normS this_norm in normalizer.outputMap[key])
                        {
                            float this_diff = Math.Abs(0.5f - normalizer.outputs[i][this_norm.ix]);
                            if (this_diff < diff)
                            {
                                norm = this_norm;
                                diff = this_diff;
                            }
                        }
                        float target_n = (normalizer.outputs[i][norm.ix] / norm.bias - norm.offset);

                        float error1 = (output_n / target_n - 1);

                        error += error1 * error1;
                    }

                }
            }

            error = (float)Math.Pow(error / count, 0.5);

            return error;
            */

            
            float error = 0.0f;
            for (int i = 0; i < normalizer.inputs.Length; i++)
            {
                if (all || normalizer.tsRatio == 1.0f || !normalizer.ts[i] )
                {
                    float[] output = Compute(normalizer.inputs[i]);
                    error += CalcError(normalizer.outputs[i], output);
                }
            }
            return error;
        }

        float CalcError(float[] target, float[] output)
        {
            float error = 0.0f;
            for (int i = 0; i < neuronCount[neuronCount.Length - 1]; i++)
            {
                float error1 = target[i] - output[i];
                error += error1 * error1;
            }
            return error;
        }

        void BackProp(float[] target, float lrate, float momentum)
        {
            int i = neuronCount.Length - 1; //output layer
            {
                for (int j = 0; j < neuronCount[i - 1] + 1; j++) //input
                {
                    float input = values[i - 1][j];
                    if (i > 1) deltas[i - 1][j] = 0.0f;
                    for (int k = 0; k < neuronCount[i]; k++) //neuron
                    {
                        float output = values[i][k];
                        float error = target[k] - output;
                        float gradient = output * (1 - output);
                        float delta = gradient * error;
                        float adjustment = input * delta * lrate + lastadjs[i][k, j] * momentum;
                        if (i > 1) deltas[i - 1][j] += delta * weights[i][k, j];
                        weights[i][k, j] += adjustment;
                        lastadjs[i][k, j] = adjustment;
                    }
                }
            }

            for (i = neuronCount.Length - 2; i > 1; i--) //hidden layer
            {
                for (int j = 0; j < neuronCount[i - 1] + 1; j++) //input
                {
                    float input = values[i - 1][j];
                    deltas[i - 1][j] = 0.0f;
                    for (int k = 0; k < neuronCount[i]; k++) //neuron
                    {
                        float output = values[i][k];
                        float gradient = output * (1 - output);
                        float delta = gradient * deltas[i][k];
                        float adjustment = input * delta * lrate + lastadjs[i][k, j] * momentum;
                        deltas[i - 1][j] += delta * weights[i][k, j];
                        weights[i][k, j] += adjustment;
                        lastadjs[i][k, j] = adjustment;
                    }
                }
            }

            i = 1; //last hidden layer
            if (i + 1 < neuronCount.Length)
                for (int j = 0; j < neuronCount[i - 1] + 1; j++) //input
                {
                    float input = values[i - 1][j];
                    for (int k = 0; k < neuronCount[i]; k++) //neuron
                    {
                        float output = values[i][k];
                        float gradient = output * (1 - output);
                        float delta = gradient * deltas[i][k];
                        float adjustment = input * delta * lrate + lastadjs[i][k, j] * momentum;
                        weights[i][k, j] += adjustment;
                        lastadjs[i][k, j] = adjustment;
                    }
                }
        }

    }
}
