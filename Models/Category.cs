using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualGallery.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public List<Image> Images { get; set; }
    }
}