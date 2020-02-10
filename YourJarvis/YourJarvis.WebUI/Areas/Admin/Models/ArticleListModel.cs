using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.WebUI.Areas.Admin.Models
{
    public class ArticleListModel
    {
        public List<Article> Articles { get; set; }
    }
}
