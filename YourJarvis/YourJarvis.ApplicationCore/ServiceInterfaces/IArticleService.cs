using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.ServiceInterfaces 
{
    public interface IArticleService  // TODO : IValidator<Article> //implements to managers
    {
        Article GetById(int id);
        List<Article> GetAll();
        bool Create(Article entity);
        void Update(Article entity);
        void Delete(Article entity);
        Article GetByIdWithTags(int id);
        Article GetArticleDetails(int id);
        List<Article> GetArticlesByTag(string category, int page, int pageSize); 
        int GetCountByTag(string category);
        void Update(Article entity, int[] categoryIds);
    }
}
