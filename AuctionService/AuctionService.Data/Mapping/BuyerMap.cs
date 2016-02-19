using AuctionService.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AuctionService.Data.Mapping
{
    public class BuyerMap : EntityTypeConfiguration<Buyer>
    {
        public BuyerMap()
        {
            ToTable("buyer");

            HasKey(b => b.Id);

            Property(b => b.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(b => b.Id)
                .HasColumnName("id")
                .IsRequired();

            Property(b => b.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
