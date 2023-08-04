using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Compare
{
    public class ModelComparison
    {
        public string sourceName { get; set; }
        public List<DataPair> sourceDescription { get; set; }
        public string targetName { get; set; }
        public List<DataPair> targetDescription { get; set; }
        public List<Comparison>  comparisons { get; set; }

        public ModelComparison(string _sourceName, List<DataPair> _sourceDescription, string _targetName, List<DataPair> _targetDescription, List<Comparison> _comparisons)
        {
            sourceName = _sourceName;
            sourceDescription = _sourceDescription;
            targetName = _targetName;
            targetDescription = _targetDescription;
            comparisons = _comparisons;
        }
    }
}
