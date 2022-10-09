using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.Property(t => t.TokenUID).IsRequired();
            builder.Property(t => t.TokenName).IsRequired().HasMaxLength(25);
            builder.Property(t => t.CostPrice).HasColumnType("decimal(18,2)");
            builder.Property(t => t.SalesPrice).HasColumnType("decimal(18,2)");
               
            builder.HasOne(b => b.Product).WithMany()
                .HasForeignKey(t => t.ProductId);    

            builder.HasOne(b => b.Donator).WithMany()
                .HasPrincipalKey(p => p.DonatorUID)
                .HasForeignKey(p => p.DonatorUID);
            builder.HasOne(b => b.Recipient).WithMany()
                .HasPrincipalKey(p => p.RecipientUID)
                .HasForeignKey(p => p.RecipientUID);  
            builder.HasOne(b => b.Store).WithMany()
                .HasPrincipalKey(p => p.StoreUID)
                .HasForeignKey(p => p.StoreUID);                                                                            
        }
    }    
}
