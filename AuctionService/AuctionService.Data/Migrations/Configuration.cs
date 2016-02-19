namespace AuctionService.Data.Migrations
{
    using Domain.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AuctionService.Data.DataContexts.AuctionServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContexts.AuctionServiceContext context)
        {
            context.Buyers.AddOrUpdate(
                new Buyer { Name = "Donald Duck" },
                new Buyer { Name = "Uncle Scrooge" }
            );

            context.Items.AddOrUpdate(
                new Item
                {
                    Name = "ASUS ZenWatch",
                    Description = "The ASUS ZenWatch, which went on sale in November, recently won an iF Product Design Award - congratulations ASUS",
                    Picture = "http://www.mersocarlin.com/auction-images/watch.png",
                    StartingPrice = 1500,
                },
                new Item
                {
                    Name = "My Digital SSD",
                    Description = "MyDigitalSSD 64GB Pocket Vault SuperSpeed USB 3.0 Portable UASP Compliant External SSD Storage Drive - MDSSD-0064G-PV",
                    Picture = "http://www.mersocarlin.com/auction-images/digitalssd.jpg",
                    StartingPrice = 700,
                },
                new Item
                {
                    Name = "Mercedes Formula 1",
                    Description = "Mercedes has confirmed reports it will reveal Formula 1 world championship title-defending 2015 car, the W06, on the first day of official winter testing.",
                    Picture = "http://www.mersocarlin.com/auction-images/mercedesf1.jpg",
                    StartingPrice = 4800,
                }
            );
        }
    }
}
