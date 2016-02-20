using AuctionService.Data.DataContexts;
using AuctionService.Domain.Contracts.Repositories;
using AuctionService.Domain.Models;

namespace AuctionService.Data.Repositories
{
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(AuctionServiceContext context)
            : base(context)
        {
        }
    }
}
