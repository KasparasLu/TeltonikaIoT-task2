using Compare;

namespace CgfToolWIthApi
{
    public class GenerateResults
    {
        public Model GetModel(Stream reader, string name)
        {
            var dataManaging = new DataManaging();
            return dataManaging.GetData(dataManaging.ReadData(reader), name);
        }

        /*public (string, string) GetPaths()
        {
            var UploadFile = new UploadedFiles();
            return (UploadFile.getSourcePath(), UploadFile.getTargetPath());
        }*/

        public (string, HashSet<string>) GetFilters()
        {
            var Filters = new FilterSaving();
            return (Filters.GetIdFilter(), Filters.GetResultFilter());
        }

        public List<DataPair> GetDescription(Model model)
        {
            var dataPair = new DataPairLists();
            return dataPair.CreateDataPairList(model.displayID, model.displayValue);
        }

        public List<Comparison> GetResults(Model source, Model target, string idFilter, HashSet<string> resultFilter)
        {
            var printingResults = new PrintingResults();
            var resultsManaging = new ResultsManaging();
            return printingResults.FilterResults(resultsManaging.GetResults(source, target).Item1, idFilter, resultFilter);
        }
    }
}
