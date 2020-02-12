using FreelancerBlog.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.Infrastructure.DataAccess.EfCoreDa 
{
    public class YourJarvisContext: DbContext
    {
        public YourJarvisContext()
        {

        }
        public YourJarvisContext(DbContextOptions<YourJarvisContext> options): base(options)
        {

        }

        public DbSet<Alan> Alans { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YourJarvisDb;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ArticleMapping.Map(modelBuilder.Entity<Article>());
            TagMapping.Map(modelBuilder.Entity<Tag>());
            ArticleTagMapping.Map(modelBuilder.Entity<ArticleTag>());
        }
    }
}
