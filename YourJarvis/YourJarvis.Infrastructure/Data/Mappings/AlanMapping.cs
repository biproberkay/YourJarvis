using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YourJarvis.ApplicationCore.Entities;

namespace YourJarvis.Infrastructure.Data.Mappings
{
    internal class AlanMapping
    {
        internal static void Map(EntityTypeBuilder<Alan> builder)
        {
            builder.HasMany(a => a.Articles)
                    .WithOne(a => a.Alan)
                    .HasForeignKey(a => a.AlanId)
                    //.OnDelete(deleteBehavior.Cascade)
                    ;
        }
    }
}
