using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    class Layer
    {
        private string layerType; // input, hidden, or output layer
        public Layer previousLayer; 
        public List<Neuron> neurons = new List<Neuron>();
        public int Size;

        // constructor
        public Layer(string type, Layer prev, int n_nodes)
        {
            layerType = type;
            previousLayer = prev;
            Size = n_nodes;

            for (int i = 0; i < n_nodes; i++)
            {
                neurons.Add(new Neuron(type, prev));
                if (type == "Input")
                    neurons[i].previousLayer = null;
                else
                    neurons[i].previousLayer = prev;
            }
        }

        // copy constructor
        // when copying a layer, only the weights matter
        // we assign a new "previous layer" because the new layer could have a different previous layer
        public Layer(Layer otherLayer, Layer prev)
        {
            layerType = otherLayer.GetLayerType();
            previousLayer = prev;
            Size = otherLayer.Size;

            for (int i = 0; i < Size; i++)
            {
                neurons.Add(new Neuron(otherLayer.neurons[i]));
                neurons[i].previousLayer = prev;
            }
        }

        public string GetLayerType()
        {
            return layerType;
        }
        
    }
}
