namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Places;

    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> place)
        {
            //place
            //   .HasIndex(p => p.IsDeleted);
        }
    }
}
