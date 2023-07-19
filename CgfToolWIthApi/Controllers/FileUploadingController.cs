using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Web;
using System.IO.Compression;
using static System.Net.Mime.MediaTypeNames;

namespace CgfToolWIthApi.Controllers
{
    [ApiController]
    public class FileUploadController : Controller
    {
        [Route("api/uploadSourceCfg")]
        [HttpPost]
        public IActionResult UploadSource(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                // Handle the case when no file is uploaded
                return BadRequest("No file uploaded.");
            }
            string filePath = file.FileName;
            if (Path.GetExtension(filePath) == ".cfg")
            {
                var UploadFile = new UploadedFiles();
                UploadFile.setSourcePath(filePath);
                return Ok($"File Uploaded!");
            }
            else return BadRequest("Wrong file format, only .cfg files are accepted");
        }

        [Route("api/uploadTargetCfg")]
        [HttpPost]
        public IActionResult UploadTarget(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                // Handle the case when no file is uploaded
                return BadRequest("No file uploaded.");
            }

            string filePath = file.FileName;
            if (Path.GetExtension(filePath) == ".cfg")
            {
                var UploadFile = new UploadedFiles();
                UploadFile.setTargetPath(filePath);
                return Ok($"File Uploaded!");
            }
            else return BadRequest("Wrong file format, only .cfg files are accepted");
        }
    }
}
