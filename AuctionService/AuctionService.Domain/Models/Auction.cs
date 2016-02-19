using System;
using System.Collections.Generic;
using System.Linq;

namespace AuctionService.Domain.Models
{
    public class Auction
    {
        #region ctor
        public Auction()
        {
            this.History = new List<AuctionHistory>();
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int BidStep { get; set; }
        public bool IsFinished { get; set; }
        
        public virtual ICollection<AuctionHistory> History { get; set; }
        public virtual Item Item { get; set; }

        public double HighestBid
        {
            get
            {
                if (this.Item == null)
                {
                    return 0;
                }

                return this.Item.StartingPrice + (this.History.Count * this.BidStep);
            }
        }

        public int HighestBidder
        {
            get
            {
                if (this.History.Count() == 0)
                {
                    return -1;
                }

                return this.History
                    .OrderByDescending(h => h.CreatedAt)
                    .ElementAt(0)
                    .BuyerId;
            }
        }
        #endregion

        #region Methods
        public void PlaceBid(int buyerId)
        {
            if (this.IsFinished)
            {
                throw new Exception("Auction has already finished!");
            }

            this.History.Add(new AuctionHistory
            {
                AuctionId = this.Id,
                BuyerId = buyerId
            });
        }
        #endregion
    }
}
