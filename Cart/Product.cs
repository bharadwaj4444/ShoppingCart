namespace ProductCart
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal PricePerItem { get; set; }
        public Offers.OfferType Offer { get; set; }

        public decimal GetDefaultTotal { get { return Count * PricePerItem; } }

        public Product(string name, decimal pricePerItem, Offers.OfferType offer = Offers.OfferType.NOOFFER)
        {
            Name = name;
            Count = 1;
            PricePerItem = pricePerItem;
            Offer = offer;
        }
    }
}
