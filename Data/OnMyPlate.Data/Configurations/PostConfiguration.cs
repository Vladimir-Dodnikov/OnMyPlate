namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post
                 .HasOne(p => p.Author)
                 .WithMany(a => a.Posts)
                 .OnDelete(DeleteBehavior.Restrict);

            post
                .HasOne(p => p.Place)
                .WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            post
                .HasIndex(p => p.IsDeleted);
        }
    }
}
