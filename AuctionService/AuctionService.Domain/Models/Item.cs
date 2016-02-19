namespace AuctionService.Domain.Models
{
    public class Item
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public double StartingPrice { get; set; }
        #endregion
    }
}
