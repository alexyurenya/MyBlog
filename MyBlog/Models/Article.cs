using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Article
    {        
        public int Id {get; set; }
        
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public byte[] HeroImage { get; set; }        
        public DateTime Date { get; set; }
       // public string Category { get; set; }

        public int? CategoryId { get; set; }  //implementing one to many relationship with category
        public Category Category { get; set; }

        public virtual List<ArticleTag> ArticlesTags { get; set; } //implementing many to many relationship with tags
        public Article()
        {
            ArticlesTags = new List<ArticleTag>();
        }
    }

   
}
