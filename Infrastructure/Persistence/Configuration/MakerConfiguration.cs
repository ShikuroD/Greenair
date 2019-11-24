using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence.Configuration
{
    public class MakerConfiguration : IEntityTypeConfiguration<Maker>
    {
        public void Configure(EntityTypeBuilder<Maker> builder)
        {
            builder.HasKey(s => s.MakerId);
            builder.Property(s => s.MakerId).HasMaxLength(3);

            builder.Property(s => s.MakerName).HasMaxLength(20);

            builder.OwnsOne(x => x.Address)
                .Property(x => x.Num).HasColumnName("AddressNum");
            builder.OwnsOne(x => x.Address)
                .Property(x => x.Street).HasColumnName("Street");
            builder.OwnsOne(x => x.Address)
                .Property(x => x.District).HasColumnName("District");
            builder.OwnsOne(x => x.Address)
                .Property(x => x.City).HasColumnName("City");
            builder.OwnsOne(x => x.Address)
                .Property(x => x.State).HasColumnName("State");
            builder.OwnsOne(x => x.Address)
                .Property(x => x.Country).HasColumnName("Country");
        }
    }
}