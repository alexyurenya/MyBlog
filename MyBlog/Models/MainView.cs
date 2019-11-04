using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class MainView
    {
        public IEnumerable<Article> Articles { get; set; }
        public string Name { get; set; }
        public SelectList Categories { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> Tags { get; set; }
    }
}
