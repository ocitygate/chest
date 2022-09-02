using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace CS.AI
{
    public class GANN
    {
        struct Individual
        {
            public NeuralNetwork nn;
            public float error;
        }

        Random rand = new Random();
        Normalizer nrm;
        int[] hiddenNodes;
        Individual[] ind;

        float error, rerror;

        void CalcTotals()
        {
            error = 0.0f;
            rerror = 0.0f;
            for (int i = 0; i < ind.Length; i++)
            {
                error += ind[i].error;
                rerror += 1 / ind[i].error;
            }
        }

        int RandomWeakest()
        {
            float r = (float)rand.NextDouble() * error;
            float inc = 0.0f;
            for (int i = 0; i < ind.Length; i++)
            {
                if (inc + ind[i].error >= r) return i;
                inc += ind[i].error;
            }
            return ind.Length - 1;
        }

        int RandomFittest()
        {
            float r = (float)rand.NextDouble() * rerror;
            float inc = 0.0f;
            for (int i = 0; i < ind.Length; i++)
            {
                if (inc + 1 / ind[i].error >= r) return i;
                inc += 1 / ind[i].error;
            }
            return ind.Length - 1;
        }

        void Sort()
        {
            float[] val = new float[ind.Length];
            for(int i = 0; i < ind.Length; i++)
            {
                val[i] = ind[i].error;
            }
            Array.Sort(val, ind);
        }

        NeuralNetwork CrossOver(params int[] pi)
        {
            NeuralNetwork ch = new NeuralNetwork(nrm);
            ch.InitNN(false, 0, hiddenNodes);

            for (int i = 1; i < ch.neuronCount.Length; i++) //layers
            {
                ch.weights[i] = new float[ch.neuronCount[i], ch.neuronCount[i - 1] + 1];

                //int cop = rand.Next(ch.neuronCount[i] + 1);

                for (int j = 0; j < ch.neuronCount[i]; j++) //neuron
                {
                    //NeuralNetwork nn = ind[pi[j < cop ? 0 : 1]].nn;
                    NeuralNetwork nn =  ind[pi[rand.Next(pi.Length)]].nn;

                    for (int k = 0; k < ch.neuronCount[i - 1] + 1; k++) //input
                    {
                        ch.weights[i][j, k] = nn.weights[i][j, k];
                    }
                }
            }

            return ch;
        }

        public GANN(Normalizer nrm, int population, params int[] hiddenNodes)
        {
            this.nrm = nrm;
            ind = new Individual[population];
            this.hiddenNodes = hiddenNodes;

            Console.Write("Creating Networks: ");

            for (int i = 0; i < ind.Length; i++)
            {
                Console.Write("{0} ", i);

                ind[i].nn = new NeuralNetwork(nrm);
                ind[i].nn.InitNN(hiddenNodes);
                ind[i].error = ind[i].nn.GetError(true);
            }

            Console.WriteLine("");
        }

        public NeuralNetwork Run(int iterations, float min_error_ch, int min_error_i, int bp_it = 0, float bp_lr = 0.0f)
        {
            int last_error_i = 0;
            float last_error_ch = float.MaxValue;

            for (int j = 0; iterations == 0 | j < iterations; j++)
            {
                CalcTotals();
                Sort();

                Console.WriteLine("iteration={0,5:0} min={1,8:0.00} max={2,8:0.00}", j, ind[0].error, ind[ind.Length - 1].error);

                if (last_error_ch - ind[0].error > min_error_ch)
                {
                    last_error_ch = ind[0].error;
                    last_error_i = 0;
                }
                else
                {
                    last_error_i++;
                }

                if (last_error_i > min_error_i)
                {
                    break;
                }

                int[] p = new int[2];
                for (int pi = 0; pi < p.Length; pi++)
                {
                    int px = -1;

                    bool repeat;
                    do
                    {
                        px = RandomFittest();
                        repeat = false;
                        for (int pj = 0; pj < pi; pj++)
                        {
                            if (p[pj] == px)
                            {
                                repeat = true;
                                break;
                            }
                        }
                    }
                    while (repeat);

                    p[pi] = px;
                }

                for(int i = 0; i < p.Length; i++)
                {
                    NeuralNetwork pr = ind[p[i]].nn;
                    pr.Run(bp_it, 0, bp_lr, 0, int.MaxValue, float.MinValue);
                    ind[p[i]].error = pr.GetError(true);
                }

                NeuralNetwork ch = CrossOver(p);
                //ch.Run(bp_it, 0, bp_lr, 0, int.MaxValue, float.MinValue);
                int die = ind.Length - 1;
                ind[die].nn = ch;
                ind[die].error = ch.GetError(true);
 
            }

            return ind[0].nn;
        }

    }
}
