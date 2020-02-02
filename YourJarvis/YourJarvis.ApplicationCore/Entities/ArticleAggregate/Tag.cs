using System.Collections.Generic;

namespace YourJarvis.ApplicationCore.Entities.ArticleAggregate
{
    public class Tag
    {
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

        public int TagId { get; set; }
        public string TagName { get; set; }

    }
}
