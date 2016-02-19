using AuctionService.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AuctionService.Data.Mapping
{
    public class AuctionHistoryMap : EntityTypeConfiguration<AuctionHistory>
    {
        public AuctionHistoryMap()
        {
            ToTable("auctionhistory");

            HasKey(ah => ah.Id);

            Property(ah => ah.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ah => ah.Id)
                .HasColumnName("id")
                .IsRequired();

            Property(ah => ah.AuctionId)
                .HasColumnName("auctionId")
                .IsRequired();

            Property(ah => ah.BuyerId)
                .HasColumnName("buyerId")
                .IsRequired();

            Property(ah => ah.CreatedAt)
                .HasColumnName("createdAt")
                .IsRequired();

            HasRequired(ah => ah.Buyer);
        }
    }
}
