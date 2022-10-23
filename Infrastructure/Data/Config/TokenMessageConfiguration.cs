using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TokenMessageConfiguration : IEntityTypeConfiguration<TokenMessage>
    {
        public void Configure(EntityTypeBuilder<TokenMessage> builder)
        {
            builder.Property(t => t.TokenUID).IsRequired();
            builder.Property(p => p.MessageText).HasMaxLength(250);
            builder.Property(p => p.MessageType).HasMaxLength(45);
            builder.Property(p => p.EmailAddress).HasMaxLength(100);
            builder.Property(p => p.EmailText).HasMaxLength(500);
            builder.Property(t => t.IsSent).HasColumnType("bit");                                                                      
        }
    }    
}
