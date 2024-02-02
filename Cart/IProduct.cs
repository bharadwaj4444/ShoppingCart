namespace ProductCart
{
    public interface IProduct
    {
        string Name { get; set; }
        int Count {  get; set; }
        decimal PricePerItem { get; set; }
        Offers.OfferType Offer { get; set; }
        decimal GetDefaultTotal { get; }
    }
}
