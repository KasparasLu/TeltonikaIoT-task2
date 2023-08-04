using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Compare
{
    public class DataPair
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public DataPair(string _Id, string _Value)
        {
            Id = _Id;
            Value = _Value;
        }
    }
}
