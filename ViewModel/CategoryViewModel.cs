using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualGallery.Models;

namespace VirtualGallery.ViewModel
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
    
    }
