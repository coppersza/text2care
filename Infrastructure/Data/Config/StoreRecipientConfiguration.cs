using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class StoreRecipientConfiguration : IEntityTypeConfiguration<StoreRecipient>
    {
        public void Configure(EntityTypeBuilder<StoreRecipient> builder)
        {
            builder.Property(p => p.StoreRecipientUID).IsRequired();

            builder.HasOne(b => b.Store).WithMany()
                .HasPrincipalKey(p => p.StoreUID)
                .HasForeignKey(p => p.StoreUID);
            builder.HasOne(b => b.Recipient).WithMany()
                .HasPrincipalKey(p => p.RecipientUID)
                .HasForeignKey(p => p.RecipientUID);          
        }
    }    
}
