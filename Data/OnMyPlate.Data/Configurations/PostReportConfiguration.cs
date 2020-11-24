namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class PostReportConfiguration : IEntityTypeConfiguration<PostReport>
    {
        public void Configure(EntityTypeBuilder<PostReport> postReport)
        {
            postReport
               .HasOne(pr => pr.Author)
               .WithMany(a => a.PostReports)
               .OnDelete(DeleteBehavior.Restrict);

            postReport
                .HasOne(pr => pr.Post)
                .WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.Restrict);

            postReport
                 .HasIndex(pr => pr.IsDeleted);
        }
    }
}
