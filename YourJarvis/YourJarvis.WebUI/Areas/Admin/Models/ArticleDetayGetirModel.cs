using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace YourJarvis.WebUI.Areas.Admin.Models 
{
    public class ArticleDetayGetirModel
    {
        public Article Article { get; set; }
        public Alan Alan { get; set; } 
        public List<Tag> Tags { get; set; } 
    }
}
