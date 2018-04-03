using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    class Program
    {
        Random rando = new Random(Guid.NewGuid().GetHashCode());

        static void Main(string[] args)
        {
            // create a network
            NeuralNetwork _network = new NeuralNetwork(2, 2, 5, 1);
            Program program = new Program();

            // dataset
            // a set for learning the logical AND gate
            List<List<double>> dataset = new List<List<double>>
            { new List<double>{0, 0, 0},
              new List<double>{1, 0, 0},
              new List<double>{0, 1, 0},
              new List<double>{1, 1, 1}
            };

            // train
            // :(

            // test the network
            while (true)
            {
                List<double> test_inputs = new List<double>();

                for (int i = 0; i < _network.inputLayer.Size; i++) { 
                    Console.WriteLine("input" + i + ": ");
                    double one = Convert.ToDouble(Console.ReadLine());
                   test_inputs.Add(one);
                }
                _network.SetInputs(test_inputs);
                _network.ForwardPropagate();

                foreach (double x in _network.GetOutputs())
                {
                    Console.WriteLine("output: " + x);
                }
            }
        }

    }
}
