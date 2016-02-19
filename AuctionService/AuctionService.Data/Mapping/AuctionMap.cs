using AuctionService.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AuctionService.Data.Mapping
{
    public class AuctionMap : EntityTypeConfiguration<Auction>
    {
        public AuctionMap()
        {
            ToTable("auction");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Id)
                .HasColumnName("id")
                .IsRequired();

            Property(a => a.ItemId)
                .HasColumnName("itemId")
                .IsRequired();

            Property(a => a.BidStep)
                .HasColumnName("bitStep")
                .IsRequired();

            Property(a => a.IsFinished)
                .HasColumnName("isFinished")
                .IsRequired();

            HasRequired(a => a.Item);

            HasMany(a => a.History);
        }
    }
}
