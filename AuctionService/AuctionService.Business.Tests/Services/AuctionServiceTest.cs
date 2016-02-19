using AuctionService.Domain.Contracts.Repositories;
using AuctionService.Domain.Contracts.Services;
using AuctionService.Domain.Models;
using Moq;
using NUnit.Framework;
using System;

namespace AuctionService.Business.Tests.Services
{
    [TestFixture]
    public class AuctionServiceTest
    {
        private Mock<IAuctionRepository> mockAuctionRepository;
        private IAuctionService auctionService;

        [SetUp]
        public void SetUp()
        {
            this.mockAuctionRepository = new Mock<IAuctionRepository>();

            this.mockAuctionRepository
                .Setup(mock => mock.Get())
                .Verifiable();

            this.mockAuctionRepository
                .Setup(mock => mock.GetById(1))
                .Verifiable();

            this.mockAuctionRepository
                .Setup(mock => mock.Create(It.IsAny<Auction>()))
                .Verifiable();

            this.mockAuctionRepository
                .Setup(mock => mock.Update(It.IsAny<Auction>()))
                .Verifiable();

            this.mockAuctionRepository
                .Setup(mock => mock.GetById(2))
                .Returns(() =>
                {
                    return new Auction
                    {
                        Id = 2,
                        BidStep = 500,
                        IsFinished = false,
                    };
                });

            this.auctionService = new Business.Services.AuctionService(mockAuctionRepository.Object);
        }

        [Test]
        public void AuctionService_Get_ReturnsAllActions()
        {
            this.auctionService.Get();

            this.mockAuctionRepository.Verify(mock => mock.Get(), Times.Once());
        }

        [Test]
        public void AuctionService_GetById_ReturnsRelatedAuction()
        {
            var auction = this.auctionService.GetById(1);

            this.mockAuctionRepository.Verify(mock => mock.GetById(1), Times.Once());
        }

        [Test]
        public void AuctionService_PlaceBid_IfAuctionDoesNotExist_ThrowsException()
        {
            Assert.Throws<Exception>(() => this.auctionService.PlaceBid(1, 1));
        }

        [Test]
        public void AuctionService_PlaceBid_OnValidAuction_UpdatesAuctionHistory()
        {
            var auction = this.auctionService.PlaceBid(2, 1);

            this.mockAuctionRepository.Verify(mock => mock.Update(It.IsAny<Auction>()), Times.Once());

            Assert.AreEqual(1, auction.History.Count);
        }

        [Test]
        public void AuctionService_Save_OnNewAuction_SaveInDB()
        {
            var auction = new Auction();

            this.auctionService.Save(auction);

            this.mockAuctionRepository.Verify(mock => mock.Create(It.IsAny<Auction>()), Times.Once());
            this.mockAuctionRepository.Verify(mock => mock.Update(It.IsAny<Auction>()), Times.Never());
        }

        [Test]
        public void AuctionService_Save_OnExistingAuction_UpdateInDB()
        {
            var auction = new Auction { Id = 2 };

            this.auctionService.Save(auction);

            this.mockAuctionRepository.Verify(mock => mock.Create(It.IsAny<Auction>()), Times.Never());
            this.mockAuctionRepository.Verify(mock => mock.Update(It.IsAny<Auction>()), Times.Once());
        }
    }
}
