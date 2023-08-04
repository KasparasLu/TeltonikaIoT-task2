using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Compare;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CgfToolWIthApi.Controllers
{
    [ApiController]
    public class ComparisonResultsController : ControllerBase
    {
        [Route("api/getComparison")]
        [HttpPost]
        public string GetComparison(IFormFile sourceFile, IFormFile targetFile)
        {
            if(Path.GetExtension(sourceFile.FileName)==".cfg" && Path.GetExtension(targetFile.FileName) == ".cfg")
            {
                var generateResults = new GenerateResults();
                var source = generateResults.GetModel(sourceFile.OpenReadStream(), sourceFile.FileName);
                var target = generateResults.GetModel(targetFile.OpenReadStream(), targetFile.FileName);
                var sourceDescription = generateResults.GetDescription(source);
                var targetDescription = generateResults.GetDescription(target);
                var (idFilter, resultFilter) = generateResults.GetFilters();
                var results = generateResults.GetResults(source, target, idFilter, resultFilter);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(new ModelComparison(source.name, sourceDescription, target.name, targetDescription, results), options);
                return jsonString;
            }
            else return "The upload files are missing, or not .cfg format";
        }
    }
}