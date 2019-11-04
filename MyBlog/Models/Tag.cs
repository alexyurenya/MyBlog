using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        
        public virtual List<ArticleTag> ArticlesTags { get; set; }

        public Tag()
        {
            ArticlesTags = new List<ArticleTag>();
        }
    }
}
