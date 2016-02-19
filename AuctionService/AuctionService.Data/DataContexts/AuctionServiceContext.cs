using AuctionService.Data.Mapping;
using AuctionService.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuctionService.Data.DataContexts
{
    public class AuctionServiceContext : DbContext
    {
        public AuctionServiceContext()
            : base("AuctionServiceContext")
        {
            Database.SetInitializer<AuctionServiceContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionHistory> AuctionHistories { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AuctionHistoryMap());
            modelBuilder.Configurations.Add(new AuctionMap());
            modelBuilder.Configurations.Add(new BuyerMap());
            modelBuilder.Configurations.Add(new ItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
