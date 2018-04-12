using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Neural_Network
{
    class Neuron
    {
        public Layer PreviousLayer;
        public List<double> Weights = new List<double>();
        public readonly string NeuronType;
        public double Bias;
        public double Value;
        Random rand = new Random(Guid.NewGuid().GetHashCode()); 
        

        // constructor
        public Neuron(string neuronType, Layer previousLayer)
        {
            NeuronType = neuronType;

            // only initialize Weights if this neuron isn't an input neuron
            if (NeuronType != "Input")
            {

                for (int i = 0; i < previousLayer.Width; i++)
                {
                    // initialize random Weights
                    Weights.Add(rand.Next(-5,5));

                }
                // initialize random Bias
                Bias = rand.Next(-5, 5);
            } else
            {
                Weights = null;
                Bias = 0;
            }
            
        }

        // copy constructor
        public Neuron(Neuron otherNeuron)
        {
            NeuronType = otherNeuron.GetNeuronType();

            // copy Weights
            Weights = new List<double>(otherNeuron.Weights);

            // copy Bias
            Bias = otherNeuron.Bias;
        }

        public double Squash(double x)
        {
            // relu
            if (x > 0) return x;
            else return 0.01 * x;
        }

        public string GetNeuronType()
        {
            return NeuronType;
        }

        public void Activate()
        {
            // add Bias
            double tempvalue = Bias;

            int count = 0;
            foreach(Neuron neuron in PreviousLayer.Neurons)
            {
                tempvalue += neuron.Value * Weights[count];
                count++;
            }
            
            // squash the Value
            Value = Squash(tempvalue);

            //Console.WriteLine(tempvalue + " to " + Value);
        }
    }
}
