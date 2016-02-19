﻿using AuctionService.Domain.Contracts.Repositories;
using AuctionService.Domain.Contracts.Services;
using AuctionService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuctionService.Business.Services
{
    public class AuctionService : IAuctionService
    {
        private IAuctionRepository _repository;

        public AuctionService(IAuctionRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Auction> Get()
        {
            return this._repository.Get();
        }

        public Auction GetById(int id)
        {
            return this._repository.GetById(id);
        }

        public Auction PlaceBid(int auctionId, int buyerId)
        {
            var auction = this.GetById(auctionId);

            if (auction == null)
            {
                throw new Exception("Auction not found!");
            }

            auction.PlaceBid(buyerId);

            this._repository.Update(auction);

            return auction;
        }

        public void Save(Auction auction)
        {
            var newAuction = auction.Id == 0 ? new Auction() : this._repository.GetById(auction.Id);

            newAuction.ItemId = auction.ItemId;
            newAuction.BidStep = auction.BidStep;
            newAuction.IsFinished = auction.IsFinished;

            foreach (var auctionHistory in auction.History)
            {
                AuctionHistory ah = newAuction.History
                    .Where(h => h.Id != 0 && h.Id == auctionHistory.Id)
                    .FirstOrDefault();

                if (ah == null)
                {
                    ah = new AuctionHistory();
                    newAuction.History.Add(ah);
                }

                ah.AuctionId = auctionHistory.AuctionId;
                ah.BuyerId = auctionHistory.BuyerId;
            }

            if (newAuction.Id == 0)
            {
                this._repository.Create(newAuction);
            }
            else
            {
                this._repository.Update(newAuction);
            }
        }
    }
}
