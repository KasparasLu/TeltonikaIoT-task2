using System.IO;
using System.IO.Compression;
//using static Compare.FileManaging;
using static System.Net.Mime.MediaTypeNames;

namespace Compare
{
    public class DataManaging
    {
        public string[] ReadData(Stream reader)
        {
            string file = "";
            using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress, true))
            using (StreamReader unzip = new StreamReader(zip))
                while (!unzip.EndOfStream) file += unzip.ReadLine();
            return file.Split(new char[] { ';', ':' });
        }
        public Model GetData(string[] pairs, string name)
        {
            var compareId    = new List<string>();
            var compareValue = new List<string>();
            var displayId    = new List<string>();
            var displayValue = new List<string>();
            for (int i = 0; i < pairs.Length - 1; i += 2)
            {
                if (!int.TryParse(pairs[i], out int temporaryIntValue) && !double.TryParse(pairs[i], out double tempDoubleValue))
                {
                    displayId.Add(pairs[i]);
                    displayValue.Add(pairs[i + 1]);
                }
                else
                {
                    compareId.Add(pairs[i]);
                    compareValue.Add(pairs[i + 1]);
                }
            }
            return new Model(name, compareId, compareValue, displayId, displayValue);
        }
    }
}
