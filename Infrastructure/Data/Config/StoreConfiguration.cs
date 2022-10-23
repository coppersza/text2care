using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(p => p.StoreUID).IsRequired();            
            builder.Property(p => p.StoreName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Nickname).HasMaxLength(100);
            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.Surname).HasMaxLength(100);
            builder.Property(p => p.FullName).HasMaxLength(250);
            builder.Property(p => p.MobileNumber).HasMaxLength(25);
            builder.Property(p => p.EmailAddress).HasMaxLength(250);
            builder.Property(p => p.Address).HasMaxLength(50);
            builder.Property(p => p.Address2).HasMaxLength(50);
            builder.Property(p => p.Suburb).HasMaxLength(50);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.PostalCode).HasMaxLength(10);
            builder.Property(p => p.DefaultToken).HasMaxLength(10);
            builder.Property(p => p.ImageURL).HasMaxLength(250);
            builder.Property(p => p.PortalUser).HasMaxLength(25);
            builder.Property(p => p.PortalPassword).HasMaxLength(25);            
            
            builder.HasOne(b => b.Country).WithMany()
                .HasForeignKey(p => p.CountryId);
              
          
        }
    }    
}
