using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.Services 
{
    public interface IArticleService // TODO : IValidator<Article>
    {
        Article GetById(int id);
        Article GetByIdWithTags(int id);
        Article GetArticleDetails(int id);
        List<Article> GetAll();
        List<Article> GetArticlesByTag(string category, int page, int pageSize); 
        int GetCountByTag(string category);
        bool Create(Article entity);
        void Update(Article entity);
        void Delete(Article entity);
        void Update(Article entity, int[] categoryIds);
    }
}
