namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> postTag)
        {
            postTag
                .HasKey(pt => new { pt.PostId, pt.TagId });

            postTag
                .HasOne(pt => pt.Post)
                .WithMany(p => p.Tags)
                .OnDelete(DeleteBehavior.Restrict);

            postTag
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.Posts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
