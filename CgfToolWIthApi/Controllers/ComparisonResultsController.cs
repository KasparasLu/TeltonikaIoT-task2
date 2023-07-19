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
        

        [HttpGet]
        public string Get()
        {
            var generateResults = new GenerateResults();
            var (sourcePath, targetPath) = generateResults.GetPaths();
            if (sourcePath != "" && targetPath != "")
            {
                var source = generateResults.GetModel(sourcePath);
                var target = generateResults.GetModel(targetPath);
                var sourceDescription = generateResults.GetDescription(source);
                var targetDescription = generateResults.GetDescription(target);
                var (idFilter, resultFilter) = generateResults.GetFilters();
                var results = generateResults.GetResults(source, target, idFilter, resultFilter);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(new ModelComparison(source.name, sourceDescription, target.name, targetDescription, results), options);
                return jsonString;
            }
            else return "The target or source is missing";
        }
    }
}