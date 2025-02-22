using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "TypescriptBook.pdf";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, "text/plain", Path.GetFileName(pathToFile));


        }
    }
}
