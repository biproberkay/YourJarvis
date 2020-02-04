using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace FreelancerBlog.Data.Mappings
{
    internal class RatingMapping
    {
        internal static void Map(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(t => t.RatingScore).IsRequired();
            builder.Property(t => t.ArticleIDfk).IsRequired();
            builder.Property(t => t.UserIDfk).IsRequired();
        }
    }
}
