using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ImageDetails
    {
        public string ImagePath { get; set; }
        public Dictionary<string, double> Details;
        public ImageDetails(string Image)
        {
            this.ImagePath = Image;
            Details = new Dictionary<string, double>();

        }
    }
}
