using System;
using System.Collections.Generic;

namespace YourJarvis.ApplicationCore.Entities.ArticleAggregate
{
    public class Comment
    {
        public Comment()
        {
            CommentChilds = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public int? CommentParentId { get; set; }
        public Comment CommentParent { get; set; }
        public virtual ICollection<Comment> CommentChilds { get; set; }
        public DateTime CommentDateCreated { get; set; }
        public string CommentName { get; set; }
        public string CommentEmail { get; set; }
        public string CommentWebSite { get; set; }
        public string CommentGravatar { get; set; }
        public string CommentBody { get; set; }
        public bool IsCommentApproved { get; set; }

        //[ForeignKey("UserIDfk")]   
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserIDfk { get; set; }

        public int ArticleIDfk { get; set; }
        //[ForeignKey("ArticleIDfk")]   
        public virtual Article Article { get; set; }


    }
}
