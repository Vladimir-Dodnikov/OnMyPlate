namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> reply)
        {
            reply
                .HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .OnDelete(DeleteBehavior.Restrict);

            reply
                .HasOne(r => r.Author)
                .WithMany(a => a.Replies)
                .OnDelete(DeleteBehavior.Restrict);

            reply
                .HasOne(r => r.Parent)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // reply
            //    .HasIndex(r => r.IsDeleted);
        }
    }
}
