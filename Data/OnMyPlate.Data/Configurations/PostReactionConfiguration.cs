namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using OnMyPlate.Data.Models.Comments;

    public class PostReactionConfiguration : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> postReaction)
        {
            postReaction
                .HasOne(pr => pr.Post)
                .WithMany(p => p.Reactions)
                .OnDelete(DeleteBehavior.Restrict);

            postReaction
                .HasOne(pr => pr.Author)
                .WithMany(p => p.PostReactions)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
