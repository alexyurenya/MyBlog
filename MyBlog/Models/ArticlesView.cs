using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class ArticlesView
    {
        public int Id { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public string Name { get; set; }
        public SelectList Categories { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } 
        public IFormFile Image { get; set; }
        public List<int> Tags { get; set; }
    }
}
