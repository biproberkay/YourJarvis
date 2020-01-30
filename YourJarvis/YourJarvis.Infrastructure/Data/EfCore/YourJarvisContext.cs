using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourJarvis.Infrastructure.Data.EfCore
{
    public class YourJarvisContext: DbContext
    {
        public YourJarvisContext(DbContextOptions<YourJarvisContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
