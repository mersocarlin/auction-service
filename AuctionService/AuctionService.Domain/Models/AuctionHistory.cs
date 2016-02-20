using System;

namespace AuctionService.Domain.Models
{
    public class AuctionHistory
    {
        #region ctor
        public AuctionHistory()
        {
            this.CreatedAt = DateTime.Now;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public int BuyerId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Auction Auction { get; set; }
        public virtual Buyer Buyer { get; set; }
        #endregion
    }
}
