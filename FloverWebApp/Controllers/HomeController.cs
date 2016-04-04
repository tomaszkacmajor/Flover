using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;
using FloverWebApp.Models;

namespace FloverWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly MainModel model;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            model = new MainModel();
        }

        public IActionResult Index()
        {
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View(model);
        }

        public IActionResult Error()
        {
            return View(model);
        }

        [HttpPost]
        public  ActionResult Index(IFormFile file)
        {
            string uploadPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");

            if (file.Length > 0)
            {
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string filePath = Path.Combine(uploadPath, fileName);
                file.SaveAs(filePath);

                model.ImagePath = filePath;
                model.ImageFileName = fileName;
            }
            return View(model);
        }


    }
}






