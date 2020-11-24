namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models.Comments;

    public class TagConfguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> tag)
        {
            tag
                .HasIndex(t => t.IsDeleted);
        }
    }
}
