using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    class Layer
    {
        public readonly string LayerType; // input, hidden, or output layer
        public List<Neuron> Neurons = new List<Neuron>();
        public readonly int Width;

        // constructor
        public Layer(string layerType, Layer previousLayer, int layerWidth)
        {
            LayerType = layerType;
            Width = layerWidth;

            for (int i = 0; i < layerWidth; i++)
            {
                Neurons.Add(new Neuron(layerType, previousLayer));
                if (layerType == "Input")
                    Neurons[i].PreviousLayer = null;
                else
                    Neurons[i].PreviousLayer = previousLayer;
            }
        }

        // copy constructor
        // when copying a layer, only the weights matter
        // we assign a new "previous layer" because the new layer could have a different previous layer
        public Layer(Layer otherLayer, Layer previousLayer)
        {
            LayerType = otherLayer.LayerType;
            Width = otherLayer.Width;

            for (int i = 0; i < otherLayer.Width; i++)
            {
                Neurons.Add(new Neuron(otherLayer.Neurons[i]));
                Neurons[i].PreviousLayer = previousLayer;
            }
        }
        
    }
}
