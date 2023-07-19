using Compare;

namespace CgfToolWIthApi
{
    public class GenerateResults
    {
        public Model GetModel(string path)
        {
            var dataManaging = new DataManaging();

            return dataManaging.getData(path);
        }

        public (string, string) GetPaths()
        {
            var UploadFile = new UploadedFiles();
            return (UploadFile.getSourcePath(), UploadFile.getTargetPath());
        }

        public (string, HashSet<string>) GetFilters()
        {
            var Filters = new FilterSaving();
            return (Filters.getIdFilter(), Filters.getResultFilter());
        }

        public List<DataPair> GetDescription(Model model)
        {
            var dataPair = new DataPairLists();
            return dataPair.createDataPairList(model.displayID, model.displayValue);
        }

        public List<Comparison> GetResults(Model source, Model target, string idFilter, HashSet<string> resultFilter)
        {
            var printingResults = new PrintingResults();
            var resultsManaging = new ResultsManaging();
            return printingResults.filterResults(resultsManaging.getResults(source, target).Item1, idFilter, resultFilter);
        }
    }
}
