using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;
using YourJarvis.ApplicationCore.InterfacesDa;
using YourJarvis.ApplicationCore.ServiceInterfaces;

namespace YourJarvis.Infrastructure.Managers
{
    public class ArticleManager : IArticleService
    {
        private IArticleDa _articleDa; 

        public ArticleManager(IArticleDa articleDa) 
        {
            _articleDa = articleDa;
        }
        public Article GetArticleDetails(int id)
        {
            return _articleDa.GetArticleDetails(id);
        }

        public bool Create(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByAlan(string alan, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Article GetById(int id)
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

        public void Update(Article article, int alanId, int[] tagIds)
        {
            throw new NotImplementedException();
        }

        public void Update(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}
