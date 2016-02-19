using AuctionService.Domain.Models;
using NUnit.Framework;
using System;

namespace AuctionService.Domain.Tests.Models
{
    [TestFixture]
    public class AuctionTest
    {
        private const int BUYER_ID = 1;

        [Test]
        public void Auction_PlaceBid_UpdatesHighestBid()
        {
            var auction = new Auction
            {
                Id = 1,
                BidStep = 100,
                ItemId = 1,
                Item = new Item
                {
                    Id = 1,
                    Name = "Item Name",
                    Description = "Item Description",
                    StartingPrice = 1000,
                }
            };

            auction.PlaceBid(BUYER_ID);

            Assert.AreEqual(1100, auction.HighestBid);
        }

        [Test]
        public void Auction_PlaceBid_EnsureIamTheHighestBidderIfSingle()
        {
            var auction = new Auction
            {
                Id = 1,
                BidStep = 100,
                ItemId = 1,
            };

            auction.PlaceBid(BUYER_ID);

            Assert.AreEqual(BUYER_ID, auction.HighestBidder);
        }

        [Test]
        public void Auction_PlaceBid_EnsureIamNotTheHighestBidderIfNotSingle()
        {
            var auction = new Auction
            {
                Id = 1,
                BidStep = 100,
                ItemId = 1,
            };

            auction.PlaceBid(BUYER_ID);
            auction.PlaceBid(BUYER_ID + 1);

            Assert.AreNotEqual(BUYER_ID, auction.HighestBidder);
        }

        [Test]
        public void Auction_PlaceBid_ThrownsExeptionIfAuctionIsFinished()
        {
            var auction = new Auction
            {
                Id = 1,
                BidStep = 100,
                IsFinished = true,
                ItemId = 1
            };

            Assert.Throws<Exception>(() => auction.PlaceBid(BUYER_ID));
        }
    }
}
