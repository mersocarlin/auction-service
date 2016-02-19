using AuctionService.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AuctionService.Data.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            ToTable("item");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Id)
                .HasColumnName("id")
                .IsRequired();

            Property(i => i.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            Property(i => i.Description)
                .HasColumnName("description")
                .HasMaxLength(200)
                .IsRequired();

            Property(i => i.Picture)
                .HasColumnName("picture")
                .HasMaxLength(500)
                .IsRequired();

            Property(i => i.StartingPrice)
                .HasColumnName("startingPrice")
                .IsRequired();
        }
    }
}
