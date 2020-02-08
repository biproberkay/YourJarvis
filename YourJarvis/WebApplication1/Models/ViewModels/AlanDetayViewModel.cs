using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourJarvis.ApplicationCore.Entities;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace WebApplication1.Models.ViewModels
{
    public class AlanDetayViewModel
    {
        public ICollection<Alan> Alans { get; set; }
        public ICollection<Article> Articles { get; set; } 

    }
}
