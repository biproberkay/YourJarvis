using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace FreelancerBlog.Data.Mappings
{
    internal class TagMapping
    {
        internal static void Map(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.TagName).IsRequired();
            
        }
    }
}