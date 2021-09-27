using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessingApp.Models
{
    public class UploadFileModel
    {
       

        public IFormFile File { get; set; }
        public string ImageOf { get; set; }
        public string DisplayImagePath { get; set; }
        // Rest of model details
        public string IsVisible { get; set; } = "hidden";
    }
}
