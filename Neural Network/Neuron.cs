using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Neural_Network
{
    class Neuron
    {
        public Layer previousLayer;
        public List<double> weights = new List<double>();
        private string neuronType;
        public double bias;
        public double value;
        Random rand = new Random(Guid.NewGuid().GetHashCode()); //reuse this if you are generating many
        

        // constructor
        public Neuron(string ntype, Layer prev)
        {
            neuronType = ntype;

            // only initialize weights if this neuron isn't an input neuron
            if (neuronType != "Input")
            {

                for (int i = 0; i < prev.Size; i++)
                {
                    // initialize random weights
                    weights.Add(rand.Next(-5,5));

                    //Console.WriteLine(weights[i]);
                }
                // initialize random bias
                bias = rand.Next(-5, 5);
                //Console.WriteLine("");
            }
            
        }

        // copy constructor
        public Neuron(Neuron otherNeuron)
        {
            neuronType = otherNeuron.GetNeuronType();

            // copy weights
            weights = new List<double>(otherNeuron.weights);

            // copy bias
            bias = otherNeuron.bias;
        }

        public double Squash(double x)
        {
            // sigmoid
            return (1 / (1 + Math.Exp(-x)));
        }

        public string GetNeuronType()
        {
            return neuronType;
        }

        public void Activate()
        {
            // add bias
            double tempvalue = bias;

            int count = 0;
            foreach(Neuron neuron in previousLayer.neurons)
            {
                tempvalue += neuron.value * weights[count];
                count++;
            }
            
            // squash the value
            value = Squash(tempvalue);

            //Console.WriteLine(tempvalue + " to " + value);
        }
    }
}
