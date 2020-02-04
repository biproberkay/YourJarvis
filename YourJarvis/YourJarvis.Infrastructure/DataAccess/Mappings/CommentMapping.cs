using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourJarvis.ApplicationCore.Entities.ArticleAggregate;

namespace FreelancerBlog.Data.Mappings
{
    internal class CommentMapping
    {
        internal static void Map(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(t => t.CommentName).IsRequired();
            builder.Property(t => t.CommentEmail).IsRequired();
            builder.Property(t => t.CommentDateCreated).IsRequired();
            builder.Property(t => t.ArticleIDfk).IsRequired();
            builder.Property(t => t.CommentBody).IsRequired();

            builder.HasMany(e => e.CommentChilds)
                .WithOne(e => e.CommentParent)
                .HasForeignKey(e => e.CommentParentId);
        }
    }
}