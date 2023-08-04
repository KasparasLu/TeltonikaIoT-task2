using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class Comparison
    {
        public string sourceId { get; set; }
        public string targetId { get; set; }
        public string sourceValue { get; set; }
        public string targetValue { get; set; }
        public string result { get; set; }

        public Comparison(string _sourceID, string _sourceValue, string _targetId, string _targetValue, string _result)
        {
            sourceId = _sourceID;
            targetId = _targetId;
            sourceValue = _sourceValue;
            targetValue = _targetValue;
            result = _result;
        }
    }
}
