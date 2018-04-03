using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    class NeuralNetwork
    {
        public int hiddenLayerWidth;
        public Layer inputLayer;
        public List<Layer> hiddenLayers = new List<Layer>();
        public Layer outputLayer;

        // constructor
        public NeuralNetwork(int n_inputs, int n_hiddenlayers, int hidden_width, int n_outputs)
        {
            hiddenLayerWidth = hidden_width;

            // create input layer
            inputLayer = new Layer("Input", null, n_inputs);

            // create hidden layers
            for (int i = 0; i < n_hiddenlayers; i++)
            {
                if (i == 0)
                {
                    Layer temp = new Layer("Hidden", inputLayer, hidden_width);
                    hiddenLayers.Add(temp);
                }
                else
                {
                    Layer temp = new Layer("Hidden", hiddenLayers[i - 1], hidden_width);
                    hiddenLayers.Add(temp);
                }

            }

            // create output layer
            outputLayer = new Layer("Output", hiddenLayers[hiddenLayers.Count - 1], n_outputs);

        }

        // copy constructor
        // when copying a network, only the weights and biases matter
        public NeuralNetwork(NeuralNetwork otherNetwork)
        {
            hiddenLayerWidth = otherNetwork.hiddenLayerWidth;

            // copy input layer
            // no need to copy weights since this is an input layer
            inputLayer = new Layer("Input", null, otherNetwork.inputLayer.Size);

            // copy hidden layers
            for (int i = 0; i < otherNetwork.hiddenLayers.Count; i++)
            {
                if (i == 0)
                {
                    Layer temp = new Layer(otherNetwork.hiddenLayers[i], inputLayer);
                    hiddenLayers.Add(temp);
                } 
                else
                {
                    Layer temp = new Layer(otherNetwork.hiddenLayers[i], hiddenLayers[i - 1]);
                    hiddenLayers.Add(temp);
                }
            }

            // create output layer

            outputLayer = new Layer(otherNetwork.outputLayer, otherNetwork.hiddenLayers[otherNetwork.hiddenLayers.Count - 1]);
        }

        // puts values into the input neurons
        public void SetInputs(List<double> inputs)
        {
            for (int i = 0; i < inputLayer.Size; i++)
            {
                inputLayer.neurons[i].value = inputs[i];
            }
        }

        // feed-forward!
        public void ForwardPropagate()
        {
            // activate neurons in hidden layers
            foreach (Layer layer in hiddenLayers)
            {
                foreach (Neuron neuron in layer.neurons)
                {
                    neuron.Activate();
                }
            }

            // activate output neurons
            foreach (Neuron neuron in outputLayer.neurons)
            {
                neuron.Activate();
            }
        }

        // returns a list of all the output values
        public List<double> GetOutputs()
        {
            List<double> outputs = new List<double>();

            foreach (Neuron neuron in outputLayer.neurons)
            {
                outputs.Add(neuron.value);
            }
            return outputs;
        }
    }
}
