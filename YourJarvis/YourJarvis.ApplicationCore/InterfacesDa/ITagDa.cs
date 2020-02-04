using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.InterfacesDa 
{
    public interface ITagDa : IRepositoryDa<Tag>
    {
        Tag GetByIdWithArticles(int id);
        void DeleteFromTag(int categoryId, int productId); 
    }
}
