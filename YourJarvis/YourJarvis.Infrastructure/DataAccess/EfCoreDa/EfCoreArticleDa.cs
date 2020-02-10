using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.InterfacesDa;
using YourJarvis.Infrastructure.DataAccess.EfCore;

namespace YourJarvis.Infrastructure.DataAccess.EfCoreDa
{
    public class EfCoreArticleDa : EfCoreDaRepository<Article, YourJarvisContext>, IArticleDa
    {
        public Article GetArticleDetails(int id)
        {
            using (var context = new YourJarvisContext())
            {
                return context.Articles
                            .Where(i => i.ArticleId == id)
                            .Include(i => i.Alan)
                            .Include(i => i.ArticleTags)
                                .ThenInclude(at => at.Tag)
                            .FirstOrDefault();
            }
        }

        public List<Article> GetArticlesByAlan(string alan, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Article GetByIdWithAlan(int id)
        {
            throw new NotImplementedException();
        }

        public Article GetByIdWithTags(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountByAlan(string alan)
        {
            throw new NotImplementedException();
        }

        public void Update(Article entity, int[] alanIds)
        {
            throw new NotImplementedException();
        }
    }
}
