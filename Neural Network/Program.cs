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

        // returns a random number with gaussian distribution provided with mean and stdDev
        public double NextGaussian(double mean, double stdDev)
        {
            double u1 = 1.0 - rando.NextDouble();
            double u2 = 1.0 - rando.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + stdDev * randStdNormal;
            return randNormal;
        }

        static void Main(string[] args)
        {
            // create a network
            NeuralNetwork _network = new NeuralNetwork(2, 2, 5, 1);
            Program program = new Program();
            
            // dataset
            // a set for learning the logical AND gate
            DataSet trainingData = new DataSet();
            trainingData.Inputs.Add(new List<double> { 0, 0 });
            trainingData.Outputs.Add(new List<double> { 0 });

            trainingData.Inputs.Add(new List<double> { 0, 1 });
            trainingData.Outputs.Add(new List<double> { 0 });

            trainingData.Inputs.Add(new List<double> { 1, 0 });
            trainingData.Outputs.Add(new List<double> { 0 });

            trainingData.Inputs.Add(new List<double> { 1, 1 });
            trainingData.Outputs.Add(new List<double> { 1 });

            // train
            for (int i = 0; i < 100000; i++)
            {
                double og_error = 0.0;
                double test_error = 0.0;

                // calculate current network error
                for (int j = 0; j < trainingData.Inputs.Count; j++)
                {
                    _network.SetInputs(trainingData.Inputs[j]);
                    _network.ForwardPropagate();
                    List<double> Outputs = _network.GetOutputs();

                    for (int k = 0; k < Outputs.Count; k++)
                    {
                        og_error += Math.Pow(trainingData.Outputs[j][k] - Outputs[k], 2) ; // squared error cost function
                    }
                }

                // create a new network based off of the last one with gaussian distribution
                NeuralNetwork _testNetwork = new NeuralNetwork(_network);
                // change hidden layer Weights and biases
                foreach (Layer layer in _testNetwork.HiddenLayers)
                {
                    foreach (Neuron neuron in layer.Neurons)
                    {
                        for (int j = 0; j < neuron.Weights.Count; j++)
                        {
                            neuron.Weights[j] += program.NextGaussian(0, 0.025);
                        }

                        neuron.Bias += program.NextGaussian(0, 0.05);
                    }
                }
                // change output layer Weights and biases
                foreach (Neuron neuron in _testNetwork.OutputLayer.Neurons)
                {
                    for (int j = 0; j < neuron.Weights.Count; j++)
                    {
                        neuron.Weights[j] += program.NextGaussian(0, 0.5);
                    }

                    neuron.Bias += program.NextGaussian(0, 0.5);
                }

                // calculate test network error
                for (int j = 0; j < trainingData.Inputs.Count; j++)
                {
                    _testNetwork.SetInputs(trainingData.Inputs[j]);
                    _testNetwork.ForwardPropagate();
                    List<double> Outputs = _testNetwork.GetOutputs();

                    for (int k = 0; k < Outputs.Count; k++)
                    {
                        test_error += Math.Pow(trainingData.Outputs[j][k] - Outputs[k], 2); // squared error cost function
                    }
                }

                // if test has less error then replace the network
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("og_error: " + og_error);
                Console.WriteLine("test_error: " + test_error);

                if (test_error < og_error)
                {
                    Console.WriteLine("updated");
                    _network = _testNetwork;
                } else
                {
                    Console.WriteLine("not updated");
                }
            }

            // test the network
            while (true)
            {
                List<double> test_inputs = new List<double>();

                for (int i = 0; i < _network.InputLayer.Width; i++) { 
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
