using AuctionService.Domain.Models;
using System.Collections.Generic;

namespace AuctionService.Domain.Contracts.Services
{
    public interface IAuctionService
    {
        IEnumerable<Auction> Get();
        Auction GetById(int id);
        void Save(Auction auction);
        Auction PlaceBid(int auctionId, int buyerId);
    }
}
