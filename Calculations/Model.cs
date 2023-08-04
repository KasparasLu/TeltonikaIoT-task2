using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class Model
    {
        public string name { get; set; }
        public List<string> comparableID { get; set; }
        public List<string> comparableValue { get; set; }
        public List<string> displayID { get; set; }
        public List<string> displayValue { get; set; }

        public Model(string _name, List<string> _comparableID, List<string> _comparableValue, List<string> _displayID, List<string> _displayValue)
        {
            name = _name;
            comparableID = _comparableID;
            comparableValue = _comparableValue;
            displayID = _displayID;
            displayValue = _displayValue;
        }

        public void PrintDescription()
        {
            Console.WriteLine("printing informaion on model {0}", name);
            for (int i = 0; i < displayID.Count; i++)
            {
                Console.WriteLine("{0}: {1}", displayID[i], displayValue[i]);
            }
            Console.WriteLine();
        }
    }
}
