namespace AuctionService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.auctionhistory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        auctionId = c.Int(nullable: false),
                        buyerId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.auction", t => t.auctionId)
                .ForeignKey("dbo.buyer", t => t.buyerId)
                .Index(t => t.auctionId)
                .Index(t => t.buyerId);
            
            CreateTable(
                "dbo.auction",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        itemId = c.Int(nullable: false),
                        bitStep = c.Int(nullable: false),
                        isFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.item", t => t.itemId)
                .Index(t => t.itemId);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 200),
                        name = c.String(nullable: false, maxLength: 50),
                        picture = c.String(nullable: false, maxLength: 500),
                        startingPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.buyer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.auctionhistory", "buyerId", "dbo.buyer");
            DropForeignKey("dbo.auction", "itemId", "dbo.item");
            DropForeignKey("dbo.auctionhistory", "auctionId", "dbo.auction");
            DropIndex("dbo.auction", new[] { "itemId" });
            DropIndex("dbo.auctionhistory", new[] { "buyerId" });
            DropIndex("dbo.auctionhistory", new[] { "auctionId" });
            DropTable("dbo.buyer");
            DropTable("dbo.item");
            DropTable("dbo.auction");
            DropTable("dbo.auctionhistory");
        }
    }
}
