using Compare;

namespace CgfToolWIthApi
{
    public class FilterSaving
    {
        public static string idFilter = "";
        public void SetIdFilter(string _idFilter)
        {
            idFilter = _idFilter;
        }
        public string GetIdFilter()
        {
            return idFilter;
        }

        public static HashSet<string> resultFilter = new HashSet<string>();
        public void SetResultFilter(string _resultFilter)
        {
            resultFilter.Clear();
            string[] results = _resultFilter.Split(new char[] { ',' });
            foreach (string result in results) resultFilter.Add(result);
        }
        public HashSet<string> GetResultFilter()
        {
            return resultFilter;
        }
    }
}
