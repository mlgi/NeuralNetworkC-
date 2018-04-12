# NeuralNetworkC#
This repository is for the purpose of storing my first neural network built from scratch.
I created this initially to make a self-driving car in Unity. My first actual network was built in python, but I figured it to be too disorganized
as I did not use any object-oriented programming styles. Since Unity supports C# and I'm more well-versed in C++ as compared to 
Python, I decided to give this a go and learn C# on the way. 

## Structure

A NeuralNetwork is made up of Layers, which are in turn made up of Neurons

### Neurons
- connects to the previous layer unless this neuron is an input neuron in the input layer
- creates a List<double> that stores all the weights for each neuron in the preceding layer
- also creates a double for the bias
- initializes the weights and bias with random numbers
- also holds the current value of the neuron to feed-forward or store if it is an output neuron
- constructor takes the neuron type(string) and the previous Layer(Layer)
- copy constructor just copies the weights and bias

### Layers
- creates a List<Neurons> of all the neurons contained in the Layer
- copy constructor needs the Layer to be copied as well as the new preceding Layer

### NeuralNetwork
- uses the preceding two classes to create a network
- constructor:
 - inputLayerWidth(int) takes the number of input neurons in the input layer
 - hiddenLayersDepth(int) takes the number of hidden layers
 - hiddenLayersWidth(int) takes the number of neurons per hidden layer
 - outputLayerWidth(int) takes the number of neurons in the output layer
 
## Training Example
The included training example uses a dataset based off of the AND logic gate
It just randomizes the weights of the network to see if it lowers the cost. If so, then the network is replaced with this new lower-cost network. Otherwise it keeps the old network unchanged.
 

