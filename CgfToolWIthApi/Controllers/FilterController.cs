using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CgfToolWIthApi.Controllers
{
    [ApiController]
    public class FilterController : Controller
    {
        [Route("api/applyIdFilter")]
        [HttpPost]
        public IActionResult IdFilter([FromBody] string idFilter)
        {
            var Filters = new FilterSaving();
            Filters.SetIdFilter(idFilter);
            return Ok($"The ID filter {idFilter} is recorded!");
        }

        [Route("api/applyResultFilter")]
        [HttpPost]

        public IActionResult ResultFilter([FromBody] string resultFilter="For multiple filters provide comma seperation For example:x,y,z(first letter capital)")
        {
            var Filters = new FilterSaving();
            if(resultFilter.Contains("Added") || resultFilter.Contains("Unchanged") || resultFilter.Contains("Removed") || resultFilter.Contains("Modified")) Filters.SetResultFilter(resultFilter);
            else BadRequest("Wrong result values");
            return Ok($"The Result filter {resultFilter} is recorded!");
        }
    }
}
