using perceptron;
using System;
using System.Data;

public class Perceptron
{
    private Data[] trainset = new Data[4];
    private float[] weight = new float[3]; // x, y, bias

    public Perceptron()
    {
        init();
        update();
        Console.WriteLine("Weight: {0}, {1}, {2}", weight[0], weight[1], weight[2]);
    }

    private void init()
    {
        this.weight = new float[3] { 0.0f, 0.0f, 0.0f };
        this.trainset[0] = new Data(0.0f, 0.0f, 1.0f, 1);
        this.trainset[1] = new Data(0.0f, 1.0f, 1.0f, 1);
        this.trainset[2] = new Data(1.0f, 0.0f, 1.0f, 1);
        this.trainset[3] = new Data(1.0f, 1.0f, 1.0f, -1);
    }

    private void update()
    {
        Random rand = new Random();
        int predicted;
        bool check = false;

        do
        {
            int r = rand.Next(0, 4);
            float weighted = (weight[0] * trainset[r].x) +
                             (weight[1] * trainset[r].y) +
                             (weight[2] * trainset[r].bias);
            if (weighted >= 0)
                predicted = 1;
            else
                predicted = -1;
            if (predicted != trainset[r].expected)
            {
                if (trainset[r].expected == 1)
                {
                    weight[0] = weight[0] + trainset[r].x;
                    weight[1] = weight[1] + trainset[r].y;
                    weight[2] = weight[2] + trainset[r].bias;
                }
                else
                {
                    weight[0] = weight[0] - trainset[r].x;
                    weight[1] = weight[1] - trainset[r].y;
                    weight[2] = weight[2] - trainset[r].bias;
                }
            }
            check = checkweight();
        } while (!check);
    }
    private bool checkweight()
    {
        int predicted = 0;
        bool[] verify = new bool[] { false, false, false, false };
        for (int i = 0; i < 4; i++)
        {
            float weighted = (weight[0] * trainset[i].x) +
                             (weight[1] * trainset[i].y) +
                             (weight[2] * trainset[i].bias);
            if (weighted >= 0)
                predicted = 1;
            else
                predicted = -1;

            if (predicted == trainset[i].expected)
            {
                verify[i] = true;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (verify[i] == false)
            {
                return false;
            }
        }


        return true;
    }
}

