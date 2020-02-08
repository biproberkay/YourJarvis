using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.ApplicationCore.Entities
{
    public class Alan
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }

        public Alan()
        {
            AlanChilds = new HashSet<Alan>();
        }
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public Alan Parent { get; set; }
        public virtual ICollection<Alan> AlanChilds { get; set; }
        public List<Article> Articles { get; set; }
    }
}
