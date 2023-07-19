namespace CgfToolWIthApi
{
    public class UploadedFiles
    {
        public static (string, string) Files = ("", "");

        private static string _dataPath = @"C:\Users\iot2\Desktop\Praktikos uždaviniai\2 užduotis\CgfToolWIthApi\data\";
        protected internal static string DataPath
        {
            get { return _dataPath; }
        }
        public void setSourcePath(string source)
        {
            Files.Item1 = DataPath+source;
        }
        public void setTargetPath(string target)
        {
            Files.Item2 = DataPath+target;
        }
        public string getSourcePath()
        {
            return Files.Item1;
        }
        public string getTargetPath()
        {
            return Files.Item2;
        }
    }
}