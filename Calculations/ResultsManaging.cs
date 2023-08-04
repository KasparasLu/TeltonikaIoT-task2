using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class ResultsManaging
    {
        public (List<Comparison>, int[]) GetResults(Model source, Model target)
        {
            int[] resultCounter = { 0, 0, 0, 0 };
            var comparisons = new List<Comparison>();

            (comparisons, resultCounter) = GetOtherResults(source, target, comparisons, resultCounter);
            (comparisons, resultCounter) = GetAdded(source, target, comparisons, resultCounter);

            return (comparisons, resultCounter);
        }
        public (List<Comparison>, int[]) GetAdded(Model source, Model target, List<Comparison> comparisons, int[] resultCounter)
        {
            for (int i = 0; i < target.comparableID.Count; i++)
            {
                if (!source.comparableID.Contains(target.comparableID[i]))
                {
                    var compare = new Comparison("", "", target.comparableID[i], target.comparableValue[i], "Added");
                    resultCounter[3]++;
                    comparisons.Add(compare);
                }
            }
            return (comparisons, resultCounter);
        }
        public (List<Comparison>, int[]) GetOtherResults(Model source, Model target, List<Comparison> comparisons, int[] resultCounter)
        {
            for (int i = 0; i < source.comparableID.Count; i++)
            {
                var compare = new Comparison("", "", "", "", "");
                compare.sourceId = source.comparableID[i];
                if (target.comparableID.Contains(source.comparableID[i]))
                {
                    compare.targetId = source.comparableID[i];
                    compare.sourceValue = source.comparableValue[i];
                    compare.targetValue = target.comparableValue[target.comparableID.FindIndex(a => a.Contains(source.comparableID[i]))];

                    if (compare.sourceValue == compare.targetValue)
                    {
                        compare.result = "Unchanged";
                        resultCounter[0]++;
                    }
                    else
                    {
                        compare.result = "Modified";
                        resultCounter[1]++;
                    }
                }
                else
                {
                    compare.sourceValue = source.comparableValue[i];
                    compare.result = "Removed";
                    resultCounter[2]++;
                }
                comparisons.Add(compare);
            }
            return (comparisons, resultCounter);
        }
    }
}
