using Compare;

namespace CgfToolWIthApi
{
    public class FilterSaving
    {
        public static string idFilter = "";
        public void setIdFilter(string _idFilter)
        {
            idFilter = _idFilter;
        }
        public string getIdFilter()
        {
            return idFilter;
        }

        public static HashSet<string> resultFilter = new HashSet<string>();
        public void setResultFilter(string _resultFilter)
        {
            resultFilter.Clear();
            string[] results = _resultFilter.Split(new char[] { ',' });
            foreach (string result in results) resultFilter.Add(result);
        }
        public HashSet<string> getResultFilter()
        {
            return resultFilter;
        }
    }
}
