namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class ReplyReportConfiguration : IEntityTypeConfiguration<ReplyReport>
    {
        public void Configure(EntityTypeBuilder<ReplyReport> replyReport)
        {
            replyReport
                .HasOne(rr => rr.Author)
                .WithMany(a => a.ReplyReports)
                .OnDelete(DeleteBehavior.Restrict);

            replyReport
                .HasOne(rr => rr.Reply)
                .WithMany(r => r.Reports)
                .OnDelete(DeleteBehavior.Restrict);

            replyReport
                .HasIndex(rr => rr.IsDeleted);
        }
    }
}
