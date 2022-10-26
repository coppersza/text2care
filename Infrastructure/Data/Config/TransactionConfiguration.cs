using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.CostPrice).HasColumnType("decimal(18,2)");
               
            builder.HasOne(b => b.Product).WithMany()
                .HasForeignKey(t => t.ProductId);    
            builder.HasOne(b => b.Donator).WithMany()
                .HasPrincipalKey(p => p.DonatorUID)
                .HasForeignKey(p => p.DonatorUID);
            builder.HasOne(b => b.Store).WithMany()
                .HasPrincipalKey(p => p.StoreUID)
                .HasForeignKey(p => p.StoreUID);       
            builder.HasOne(b => b.Country).WithMany()
                .HasForeignKey(p => p.CountryId);                                                                                     
        }
    }    
}
