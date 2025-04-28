using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perceptron
{
    public class Data
    {
        public float x;
        public float y;
        public float bias;
        public int expected;

        public Data(float x, float y, float bias, int expected)
        {
            this.x = x;
            this.y = y;
            this.bias = bias;
            this.expected = expected;
        }
    }
}