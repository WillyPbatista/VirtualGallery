using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualGallery.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; } 
        public string? Path { get; set; }
        public string? PhysicalPath { get; set; }
        public string? ContentType { get; set; }   
        public int Size { get; set; } 
        public DateTime Date { get; set; }
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public Author? Author { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

    }
}