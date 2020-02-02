using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.Services;
using YourJarvis.ApplicationCore.Abstract;

namespace YourJarvis.Infrastructure.Managers
{
    public class ArticleManager : IArticleService
    {
        private IArticle _article;

        public ArticleManager(IArticle article)
        {
            _article = article;
        }
        public bool Create(Article entity)
        {
            if (Validate(entity))
            {
                _article.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Article entity)
        {
            _article.Create(entity);
        }

        public List<Article> GetAll()
        {
            return _article.GetAll();
        }

        public Article GetArticleDetails(int id)
        {
            return _article.GetArticleDetails(id);
        }

        public List<Article> GetArticlesByTag(string category, int page, int pageSize)
        {
            return _article.GetArticlesByTag(category, page, pageSize);
        }

        public Article GetById(int id)
        {
            return _article.GetById(id);
        }

        public Article GetByIdWithTags(int id)
        {
            return _article.GetByIdWithTags(id);
        }

        public int GetCountByTag(string category)
        {
            return _article.GetCountByTag(category);
        }

        public void Update(Article entity)
        {
            _article.Update(entity);
        }

        public void Update(Article entity, int[] tagIds) 
        {
            _article.Update(entity, tagIds);
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
