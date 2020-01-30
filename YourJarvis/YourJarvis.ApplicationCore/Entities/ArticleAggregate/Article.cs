using System;
using System.Collections.Generic;

namespace YourJarvis.ApplicationCore.Entities.ArticleAggregate
{
    public class Article
    {
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSummary { get; set; }
        public DateTime ArticleDateCreated { get; set; }
        public DateTime? ArticleDateModified { get; set; }
        public string ArticleBody { get; set; }
        public Int64? ArticleViewCount { get; set; }

        public string ArticleStatus { get; set; }

        public bool IsOpenForComment { get; set; }


        //[ForeignKey("ArticleUserIDfk")]   
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserIDfk { get; set; }


    }
}
