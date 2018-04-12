using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network
{
    class DataSet
    {
        public List<List<double>> Inputs;
        public List<List<double>> Outputs;

        // empty constructor
        public DataSet()
        {
            Inputs = new List<List<double>>();
            Outputs = new List<List<double>>();
        }


    }
}
