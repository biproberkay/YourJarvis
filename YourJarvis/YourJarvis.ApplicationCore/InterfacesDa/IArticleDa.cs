using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.InterfacesDa
{
    public interface IArticleDa : IRepositoryDa<Article>
    {
        List<Article> GetArticlesByAlan(string alan, int page, int pageSize);

        Article GetArticleDetails(int id);

        int GetCountByAlan(string alan);
        Article GetByIdWithTags(int id); 
        Article GetByIdWithAlan(int id);  
        void Update(Article entity, int[] alanIds);
    }
}
