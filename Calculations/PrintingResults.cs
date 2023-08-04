using System;
using static Compare.Cosmetics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Compare
{
    public class PrintingResults
    {
        private string _format = "{0, 9}| {1, 35}| {2, 9}| {3, 35}| {4}";
        protected internal string Format
        {
            get { return _format; }
        }
        public void PrintResults(List<Comparison> comparisons, int[] resultCounter, string idFilter, HashSet<string> resultFilter)
        {
            List<Comparison> filteredList = FilterResults(comparisons, idFilter, resultFilter);

            PrintResultsTable(filteredList, idFilter, resultFilter);

            PrintResultsCount(resultCounter);

        }

        public List<Comparison> FilterResults(List<Comparison> unfiltered, string idFilter, HashSet<string> resultFilter)
        {
            var cosmetics = new Cosmetics();
            var filtered = new List<Comparison>();
            for(int i=0; i < unfiltered.Count; i++)
            {
                if (cosmetics.CheckFilters(idFilter, resultFilter, unfiltered[i])) filtered.Add(unfiltered[i]);
            }
            return filtered;
        }
        public void PrintResultsTable(List<Comparison> comparisons, string idFilter, HashSet<string> resultFilter)
        {
            var cosmetics = new Cosmetics();
            Console.WriteLine(Format, "Source ID", "Source value", "Target ID", "Target value", "Result");
            foreach(Comparison compare in comparisons)
            {
                cosmetics.ChangeColour(compare.result);
                Console.WriteLine(Format, compare.sourceId, compare.sourceValue, compare.targetId, compare.targetValue, compare.result);
            }
        }
        public void PrintResultsCount(int[] resultCounter)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < resultCounter.Length; i++)
                Console.WriteLine("{0}: {1}", "UMRA"[i], resultCounter[i]);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
