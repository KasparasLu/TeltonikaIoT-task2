using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class DataPairLists
    {
        public List<DataPair> CreateDataPairList(List<string> Id, List<string> Value)
        {
            List<DataPair> List = new List<DataPair>();
            for (int i = 0; i < Id.Count; i++)
            {
                List.Add(new DataPair(Id[i], Value[i]));
            }
            return List;
        }
    }
}
