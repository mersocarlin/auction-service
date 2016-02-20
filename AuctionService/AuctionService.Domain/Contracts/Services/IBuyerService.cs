using AuctionService.Domain.Models;
using System.Collections.Generic;

namespace AuctionService.Domain.Contracts.Services
{
    public interface IBuyerService
    {
        IEnumerable<Buyer> Get();
    }
}
