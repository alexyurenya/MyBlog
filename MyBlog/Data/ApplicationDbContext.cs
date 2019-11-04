using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //!

            modelBuilder.Entity<ArticleTag>()
                .HasKey(t => new { t.ArticleId, t.TagId }); 

            modelBuilder.Entity<ArticleTag>()
                .HasOne(sc => sc.Article)
                .WithMany(s => s.ArticlesTags)
                .HasForeignKey(sc => sc.ArticleId);

            modelBuilder.Entity<ArticleTag>()
                .HasOne(sc => sc.Tag)
                .WithMany(c => c.ArticlesTags)
                .HasForeignKey(sc => sc.TagId);
        }

    }
}
