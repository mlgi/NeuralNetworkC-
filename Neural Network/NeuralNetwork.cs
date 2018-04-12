using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    class NeuralNetwork
    {
        public Layer InputLayer;
        public List<Layer> HiddenLayers = new List<Layer>();
        public Layer OutputLayer;

        // constructor
        public NeuralNetwork(int inputLayerWidth, int hiddenLayersDepth, int hiddenLayersWidth, int outputLayerWidth)
        {
            // create input layer
            InputLayer = new Layer("Input", null, inputLayerWidth);
            Layer previousLayer = InputLayer;

            // create hidden layers
            for (int i = 0; i < hiddenLayersDepth; i++)
            {
                Layer temp = new Layer("Hidden", previousLayer, hiddenLayersWidth);
                HiddenLayers.Add(temp);
                previousLayer = temp;
            }

            // create output layer
            OutputLayer = new Layer("Output", previousLayer, outputLayerWidth);
        }

        // copy constructor
        // when copying a network, only the weights and biases matter
        public NeuralNetwork(NeuralNetwork otherNetwork)
        {
            // copy input layer
            // no need to copy weights since this is an input layer
            InputLayer = new Layer("Input", null, otherNetwork.InputLayer.Width);
            Layer previousLayer = InputLayer;

            // copy hidden layers
            for (int i = 0; i < otherNetwork.HiddenLayers.Count; i++)
            {
                Layer temp = new Layer(otherNetwork.HiddenLayers[i], previousLayer);
                HiddenLayers.Add(temp);
                previousLayer = temp;
            }

            // create output layer
            OutputLayer = new Layer(otherNetwork.OutputLayer, previousLayer);
        }

        // puts values into the input neurons
        public void SetInputs(List<double> inputs)
        {
            for (int i = 0; i < InputLayer.Width; i++)
            {
                InputLayer.Neurons[i].Value = inputs[i];
            }
        }

        // feed-forward!
        public void ForwardPropagate()
        {
            // neurons in input layers dont need to be activated
            // activate neurons in hidden layers
            foreach (Layer layer in HiddenLayers)
            {
                foreach (Neuron neuron in layer.Neurons)
                {
                    neuron.Activate();
                }
            }

            // activate output neurons
            foreach (Neuron neuron in OutputLayer.Neurons)
            {
                neuron.Activate();
            }
        }

        // returns a list of all the output values
        public List<double> GetOutputs()
        {
            List<double> outputs = new List<double>();

            foreach (Neuron neuron in OutputLayer.Neurons)
            {
                outputs.Add(neuron.Value);
            }
            return outputs;
        }
    }
}
