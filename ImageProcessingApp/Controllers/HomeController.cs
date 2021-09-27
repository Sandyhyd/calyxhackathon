using ImageProcessingApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            UploadFileModel model = new UploadFileModel();
            return View(model);
        }

      
        [HttpPost]
        public async Task<ActionResult> Index([FromForm]UploadFileModel model)
        {
            // DO Stuff
            string filePath = string.Empty;
            if (model.File.Length > 0)
            {
                filePath = Path.Combine(webHostEnvironment.WebRootPath, "images");

                using (var stream = System.IO.File.Create(filePath+@"\"+model.File.FileName))
                {
                    await model.File.CopyToAsync(stream);
                }
            }
            var sampleEyeData = new MLModelEye.ModelInput()
            {
                ImageSource = filePath +@"\"+ model.File.FileName,
            };
            MLModelEye predModel = new MLModelEye();
            var result2 = predModel.Predict(sampleEyeData,model.ImageOf);
            
            ViewData.Add("Prediction", result2.Prediction);
            ViewData.Add("Score", result2.Score[0]);
            ViewData.Add("DisplayImagePath", model.File.FileName);
            model.IsVisible = "visible";

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
