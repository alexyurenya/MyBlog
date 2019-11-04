using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
       
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
       

        public  IActionResult Index(int? category, string name, DateTime startdateTime, DateTime enddateTime)
          {
           

            IQueryable<Article> articles = db.Articles.Include(p => p.Category);
               if (category != null && category != 0)
               {
                   articles = articles.Where(p => p.CategoryId == category);
               }

               if (!String.IsNullOrEmpty(name))
               {
                   articles = articles.Where(p => p.Name.Contains(name));
               }

              
               //if (startdateTime == null) startdateTime = DateTime.MinValue;
               if (enddateTime ==DateTime.MinValue) enddateTime = DateTime.Now;
                articles = articles.Where(p => p.Date>=startdateTime && p.Date <= enddateTime);

               

             List<Category> categories = db.Categories.OrderBy(p=>p.Name).ToList();
               categories.Insert(0, new Category { Name = "All", Id = 0 });

            MainView viewModel = new MainView
            {
                Articles = articles.ToList(),
                Categories = new SelectList(categories, "Id", "Name"),
                Name = name,
                StartDate = startdateTime,
                EndDate = enddateTime

            };

               return View(viewModel);

          }

      /*  public ActionResult Index()
        {
            var article = db.Articles.Include(p => p.Category);
            return View(article.ToList());
        }*/

       /* public async Task<IActionResult> Index()
        {
            return View ( await db.Articles.Include(a=>a.Category).ToListAsync());
        }*/

        public async Task<IActionResult> AdminView()
        {
            return View(await db.Articles.OrderBy(a=>a.Name).ToListAsync());
        }

        public async Task<IActionResult> CategoryPage()
        {
            return View(await db.Categories.OrderBy(c=>c.Name).ToListAsync());
        }

        public IActionResult TagPage()
        {
            return View();
        }

        [HttpGet]
        [ActionName("ArticleDetail")]
        public async Task<IActionResult> ArticleDetail(int? id)
        {
            if (id != null)
            {
                // Article article = await db.Articles.FirstOrDefaultAsync(i => i.Id == id);
                Article article = await db.Articles.Include(a => a.ArticlesTags).ThenInclude(at => at.Tag).FirstOrDefaultAsync(i => i.Id == id);
                
                if (article != null)
                {
                    ArticleImage articleImage = new ArticleImage { Artical = article };
                    if (article.HeroImage != null) articleImage.Image = Convert.ToBase64String(article.HeroImage);
                    
                    return View(articleImage);
                }
            }
            return NotFound();
        }

        public IActionResult CreateNewArticle()
        {
            ViewBag.Tags = new SelectList(db.Tags.OrderBy(t=>t.Name).ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.OrderBy(c=>c.Name).ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewArticle(ArticlesView av)
        {
            byte[] imageData = null;


            Article artical = new Article { Name = av.Name, CategoryId = av.CategoryId,
                ShortDescription =av.ShortDescription, Description=av.Description, Date = av.Date };
            if (av.Image != null)
            {


                using (var binaryReader = new System.IO.BinaryReader(av.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)av.Image.Length);
                }

                artical.HeroImage = imageData;
            }

            db.Add(artical); // adding artical
            await db.SaveChangesAsync();

            foreach (var tagId in av.Tags)
            {
                var tag = db.Tags.Find(tagId);
                ArticleTag articleTag = new ArticleTag { Article = artical, Tag = tag };
                db.Add(articleTag);
            }
            await db.SaveChangesAsync(); //adding tags

            return RedirectToAction("AdminView");
        }

        public IActionResult CreateNewTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewTag(Tag t)
        {
            Tag tag = new Tag { Name=t.Name};

            db.Add(tag);
            await db.SaveChangesAsync();

            return RedirectToAction("AdminView");
        }

        public IActionResult CreateNewCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("CategoryPage");
        }


        public IActionResult DeleteTag()
        {
            TagModel tm = new TagModel

            {
                TagModelList = db.Tags.OrderBy(t => t.Name).ToList()
            };          
            
            return View(tm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTag(TagModel tm)
        {
            var selectedTags = tm.TagModelList.Where(it => it.IsChecked == true);
            foreach (var item in selectedTags)
            {

                db.Remove(item);
            }
            await db.SaveChangesAsync(); //removing tags

            return RedirectToAction("AdminView");
        }

        [HttpGet]
        [ActionName("DeleteCategory")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    await db.SaveChangesAsync();
                    return RedirectToAction("CategoryPage");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("DeleteArticle")]
        public async Task<IActionResult> ConfirmDeleteArticle(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                    return View(article);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArticle(int? id)
        {
            if (id != null)
            {
                Article article = await db.Articles.FirstOrDefaultAsync(p => p.Id == id);
                if (article != null)
                {
                    db.Articles.Remove(article);
                    await db.SaveChangesAsync();
                    return RedirectToAction("AdminView");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null)
                    return View(category);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            // db.Categories.Update(category);
            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("CategoryPage");
        }

        [HttpGet]
        public ActionResult EditArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
           Article article = db.Articles.Find(id);
            if (article != null)
            {
               
                SelectList category = new SelectList(db.Categories, "Id", "Name", article.CategoryId);
                ViewBag.Categories = category;
                return View(article);
            }
            return RedirectToAction("AdminView");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditArticle(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AdminView");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
