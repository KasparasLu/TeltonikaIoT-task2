using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    internal class Cosmetics
    {
        public void ChangeColour(string result)
        {
            if (result[0] == 'A') Console.ForegroundColor = ConsoleColor.Green;
            else if (result[0] == 'U') Console.ForegroundColor = ConsoleColor.Gray;
            else if (result[0] == 'R') Console.ForegroundColor = ConsoleColor.Red;
            else if (result[0] == 'M') Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.White;
        }

        public bool CheckFilters(string id, HashSet<string> result, Comparison data)
        {
            if (id == "" && result.Count() == 0) return true; 
            if (!(id == "") && !data.sourceId.Contains(id) && !data.targetId.Contains(id)) return false;
            if (result.Count() > 0 && !result.Contains(data.result)) return false;
            return true;
        }
    }
}
