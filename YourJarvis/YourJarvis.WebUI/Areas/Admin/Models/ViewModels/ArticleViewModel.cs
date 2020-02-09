using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.WebUI.Areas.Admin.Models.ViewModels
{
    public class ArticleViewModel
    {
        public IEnumerable<Article> Articles { get; set; } 
        public IEnumerable<ArticleTag> ArticleTags { get; set; }
        public IEnumerable<Alan> Alans { get; set; } 
    }
}
