using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.InterfacesDa;

namespace YourJarvis.Infrastructure.Data.EfCore
{
    public class EfCoreDaArticle : EfCoreDaRepository<Article, YourJarvisContext>, IArticleDa
    {
#if false 
        public Article GetArticleDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByTag(string category, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Article GetByIdWithTags(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountByTag(string category)
        {
            throw new NotImplementedException();
        }

        public void Update(Article entity, int[] categoryIds)
        {
            throw new NotImplementedException();
        } 
#elif true

        public Article GetByIdWithTags(int id)
        {
            using (var context = new YourJarvisContext())
            {
                return context.Articles
                        .Where(i => i.ArticleId == id)
                        .Include(i => i.ArticleTags)
                        .ThenInclude(i => i.Tag)
                        .FirstOrDefault();
            }
        }

        public int GetCountByTag(string category)
        {
            using (var context = new YourJarvisContext())
            {
                var Articles = context.Articles.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    Articles = Articles
                                .Include(i => i.ArticleTags)
                                .ThenInclude(i => i.Tag)
                                .Where(i => i.ArticleTags.Any(a => a.Tag.TagName.ToLower() == category.ToLower()));
                }

                return Articles.Count();
            }
        }

        public Article GetArticleDetails(int id)
        {
            using (var context = new YourJarvisContext())
            {
                return context.Articles
                            .Where(i => i.ArticleId == id)
                            .Include(i => i.ArticleTags)
                            .ThenInclude(i => i.Tag)
                            .FirstOrDefault();
            }
        }

        public List<Article> GetArticlesByTag(string tag, int page, int pageSize)
        {
            using (var context = new YourJarvisContext())
            {
                var Articles = context.Articles.AsQueryable();

                if (!string.IsNullOrEmpty(tag))
                {
                    Articles = Articles
                                .Include(i => i.ArticleTags)
                                .ThenInclude(i => i.Tag)
                                .Where(i => i.ArticleTags.Any(a => a.Tag.TagName.ToLower() == tag.ToLower()));
                }

                return Articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void Update(Article entity, int[] tagIds)
        {
            using (var context = new YourJarvisContext())
            {
                var Article = context.Articles
                                   .Include(i => i.ArticleTags)
                                   .FirstOrDefault(i => i.ArticleId == entity.ArticleId);

                if (Article != null)
                {
                    Article.ArticleTitle = entity.ArticleTitle;
                    Article.ArticleSummary = entity.ArticleSummary;
                    //Article.ImageUrl = entity.ImageUrl;
                    //Article.Price = entity.Price;

                    Article.ArticleTags = tagIds.Select(tagid => new ArticleTag()
                    {
                        TagId = tagid,
                        ArticleId = entity.ArticleId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
#endif
    }
}
