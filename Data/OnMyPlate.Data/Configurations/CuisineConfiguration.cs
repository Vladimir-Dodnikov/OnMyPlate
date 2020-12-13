namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnMyPlate.Data.Models;

    public class CuisineConfiguration : IEntityTypeConfiguration<Cuisine>
    {
        public void Configure(EntityTypeBuilder<Cuisine> cuisine)
        {
            cuisine
                .HasOne(c => c.Place)
                .WithMany(p => p.Cuisines)
                .OnDelete(DeleteBehavior.Restrict);

            // cuisine
            //    .HasIndex(x => x.IsDeleted);
        }
    }
}
