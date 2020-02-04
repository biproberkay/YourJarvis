using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.ServiceInterfaces;
using YourJarvis.ApplicationCore.InterfacesDa;

namespace YourJarvis.Infrastructure.Managers
{
    public class ArticleManager : IArticleService
    {
        private IArticleDa _articleDa;

        public ArticleManager(IArticleDa articleDa)
        {
            _articleDa = articleDa;
        }
        public bool Create(Article entity)
        {
            if (Validate(entity))
            {
                _articleDa.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Article entity)
        {
            _articleDa.Create(entity);
        }

        public List<Article> GetAll()
        {
            return _articleDa.GetAll();
        }

        public Article GetArticleDetails(int id)
        {
            return _articleDa.GetArticleDetails(id);
        }

        public List<Article> GetArticlesByTag(string category, int page, int pageSize)
        {
            return _articleDa.GetArticlesByTag(category, page, pageSize);
        }

        public Article GetById(int id)
        {
            return _articleDa.GetById(id);
        }

        public Article GetByIdWithTags(int id)
        {
            return _articleDa.GetByIdWithTags(id);
        }

        public int GetCountByTag(string category)
        {
            return _articleDa.GetCountByTag(category);
        }

        public void Update(Article entity)
        {
            _articleDa.Update(entity);
        }

        public void Update(Article entity, int[] tagIds)
        {
            _articleDa.Update(entity, tagIds);
        }
        public string ErrorMessage { get; set; }
        public bool Validate(Article entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.ArticleTitle))
            {
                ErrorMessage += "ürün ismi girmelisiniz";
                isValid = false;
            }

            return isValid;
        }
    }
}
