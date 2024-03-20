using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualGallery.Models;

namespace VirtualGallery.ViewModel
{
    public class ImageViewModel
    {
        
        public int ID { get; set; }
        public string? Name { get; set; } 
        public string? Path { get; set; }
        public string? PhysicalPath { get; set; }
        public string? ContentType { get; set; }   
        public int Size { get; set; } 
        public DateTime Date { get; set; }
        public int AuthorID { get; set; }
        public Author? Author { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}