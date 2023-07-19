using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Compare;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CgfToolWIthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class ComparisonResultsController : ControllerBase
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

        [HttpGet]
        public string Get()
        {
            
            var (sourcePath, targetPath) = GetPaths();
            if (sourcePath != "" && targetPath != "")
            {
                var source = GetModel(sourcePath);
                var target = GetModel(targetPath);
                var sourceDescription = GetDescription(source);
                var targetDescription = GetDescription(target);
                var (idFilter, resultFilter) = GetFilters();
                var results = GetResults(source, target, idFilter, resultFilter);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(new ModelComparison(source.name, sourceDescription, target.name, targetDescription, results), options);
                return jsonString;
            }
            else return "The target or source is missing";
        }
    }
}