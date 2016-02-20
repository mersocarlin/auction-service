using AuctionService.Business.Services;
using AuctionService.Domain.Contracts.Repositories;
using AuctionService.Domain.Contracts.Services;
using Moq;
using NUnit.Framework;

namespace AuctionService.Business.Tests.Services
{
    [TestFixture]
    public class BuyerServiceTest
    {
        private Mock<IBuyerRepository> mockBuyerRepository;
        private IBuyerService buyerService;

        [SetUp]
        public void SetUp()
        {
            this.mockBuyerRepository = new Mock<IBuyerRepository>();

            this.mockBuyerRepository
                .Setup(mock => mock.Get())
                .Verifiable();

            this.buyerService = new BuyerService(mockBuyerRepository.Object);
        }

        [Test]
        public void AuctionService_Get_ReturnsAllActions()
        {
            this.buyerService.Get();

            this.mockBuyerRepository.Verify(mock => mock.Get(), Times.Once());
        }
    }
}
