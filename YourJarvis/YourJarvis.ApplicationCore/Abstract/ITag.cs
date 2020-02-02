using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.Abstract 
{
    public interface ITag : IRepository<Tag>
    {
        Tag GetByIdWithArticles(int id);
        void DeleteFromTag(int categoryId, int productId); 
    }
}
