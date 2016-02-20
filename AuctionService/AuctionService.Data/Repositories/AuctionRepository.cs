using AuctionService.Data.DataContexts;
using AuctionService.Domain.Contracts.Repositories;
using AuctionService.Domain.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AuctionService.Data.Repositories
{
    public class AuctionRepository : Repository<Auction>, IAuctionRepository
    {
        public AuctionRepository(AuctionServiceContext context)
            : base(context)
        {

        }

        public override IEnumerable<Auction> Get()
        {
            return this._context.Auctions
                .Include(a => a.Item)
                .Include(a => a.History.Select(h => h.Buyer))
                .ToList();
        }

        public override Auction GetById(int id)
        {
            return this._context.Auctions
                .Include(a => a.Item)
                .Include(a => a.History.Select(h => h.Buyer))
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }
    }
}
