namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class ReplyReactionConfiguration : IEntityTypeConfiguration<ReplyReaction>
    {
        public void Configure(EntityTypeBuilder<ReplyReaction> replyReaction)
        {
            replyReaction
                .HasOne(rr => rr.Reply)
                .WithMany(r => r.Reactions)
                .OnDelete(DeleteBehavior.Restrict);

            replyReaction
                .HasOne(rr => rr.Author)
                .WithMany(r => r.ReplyReactions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
