using System.Collections.Generic;
using AuctionService.Domain.Contracts.Services;
using AuctionService.Domain.Models;
using AuctionService.Domain.Contracts.Repositories;

namespace AuctionService.Business.Services
{
    public class BuyerService : IBuyerService
    {
        private IBuyerRepository _repository;

        public BuyerService(IBuyerRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Buyer> Get()
        {
            return this._repository.Get();
        }
    }
}
