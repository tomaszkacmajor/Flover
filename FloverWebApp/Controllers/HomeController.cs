//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Mvc;

//namespace FloverWebApp.Controllers
//{
//    public class HomeController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult About()
//        {
//            ViewData["Message"] = "Your application description page.";

//            return View();
//        }

//        public IActionResult Contact()
//        {
//            ViewData["Message"] = "Your contact page.";

//            return View();
//        }

//        public IActionResult Error()
//        {
//            return View();
//        }
//    }
//}

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
        public IActionResult Index()
        {
            return View(new MainModel());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(new MainModel());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View(new MainModel());
        }

        public IActionResult Error()
        {
            return View(new MainModel());
        }

        private IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            string uploads = Path.Combine(_environment.WebRootPath, "uploads");
            MainModel model = new MainModel();

            if (file.Length > 0)
            {
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string filePath = Path.Combine(uploads, fileName);
                await file.SaveAsAsync(filePath);


                model.ImagePath = filePath;
            }

            return View(model);
        }
    }
}
