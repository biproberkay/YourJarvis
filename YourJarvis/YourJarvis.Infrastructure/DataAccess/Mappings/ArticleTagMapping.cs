using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace FreelancerBlog.Data.Mappings
{
    internal class ArticleTagMapping
    {
        internal static void Map(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.HasKey(x => new { x.ArticleId, x.TagId });
        }
    }
}