using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.ServiceInterfaces
{
    public interface IArticleService : IServiceRepository<Article>
    {
        Article GetArticleDetails(int id);
        List<Article> GetArticlesByAlan(string alan, int page, int pageSize);
        Article GetByIdWithAlan(int id);
        Article GetByIdWithTags(int id);
        int GetCountByAlan(string alan);
        void Update(Article article, int alanId, int[] tagIds);
    }
}
