using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.InterfacesDa
{
    public interface IArticleDa : IRepositoryDa<Article>
    {
        List<Article> GetArticlesByTag(string category, int page, int pageSize);

        Article GetArticleDetails(int id);

        int GetCountByTag(string category);
        Article GetByIdWithTags(int id);
        void Update(Article entity, int[] categoryIds);
    }
}
