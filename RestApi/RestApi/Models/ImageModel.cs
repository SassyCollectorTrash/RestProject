using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class ImageModel
    {
        public string Name { get; set; }
        public string ImageBytes { get; set; }
        public ushort Widh { get; set; }
        public ushort Height { get; set; }
    }
}
