# NeuralNetworkC#
## Intro
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
- copy constructer needs the Layer to be copied as well as the new preceding Layer

### NeuralNetwork
- uses the preceding two classes to create a network
- constructor:
 - n_inputs(int) takes the number of input neurons in the input layer
 - n_hiddenlayers(int) takes the number of hidden layers
 - n_hidden_width(int) takes the number of neurons per hidden layer
 - n_outputs(int) takes the number of neurons in the output layer

