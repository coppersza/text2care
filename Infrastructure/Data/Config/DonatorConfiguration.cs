using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{

    public class DonatorConfiguration : IEntityTypeConfiguration<Donator>
    {
        public void Configure(EntityTypeBuilder<Donator> builder)
        {
            builder.Property(p => p.DonatorUID).IsRequired();
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
            
            builder.HasOne(b => b.Country).WithMany()
                .HasForeignKey(p => p.CountryId);
          
        }
    }    
}
