using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessingApp.Models
{
    public class ScanImageModel
    {
        public string FilePath { get; set; }

        public List<ImageTypeModel> ImageTypes { get; set; } = new List<ImageTypeModel>();
    }

    public class ImageTypeModel
    {
        public string ImageType { get; set; }
        public string ImageValue { get; set; }
    }
}
