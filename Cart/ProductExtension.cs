namespace ProductCart
{
    /// <summary>
    /// Product offer cost calculation is moved to extension as it gives flexibility
    /// to update the calculations or add new calculations and keeps the product 
    /// object light weight
    /// </summary>
    public static class ProductExtension
    {
        /// <summary>
        /// Calculate offer price for a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Offer price</returns>
        public static decimal GetOfferCost(this Product product)
        {
            switch (product.Offer)
            {
                //Buy 1 get 1
                case Offers.OfferType.BOGO: return product._CalculateBOGOType1();
                //Get 3 for the price of 2
                case Offers.OfferType.GET3FOR2: return product._CalculateGET3FOR2();
                //Default no offer
                default: return product.GetDefaultTotal;
            }
        }

        /// <summary>
        /// Type of buy 1 get 1 will give 50% off on single item
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Buy 1 get 1 offer total price</returns>
        private static decimal _CalculateBOGOType1(this Product product)
        {
            return product.GetDefaultTotal / 2;
        }

        /// <summary>
        /// Type 2 buy 1 get 1 will not give 50% off on single item
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Buy 1 get 1 offer total price except single items</returns>
        private static decimal _CalculateBOGOType2(this Product product)
        {
            return product._CalculateBOGOType1() + (product.Count % 2) * product.PricePerItem;
        }

        /// <summary>
        /// Get 3 for the price of 2 and full price if it is less than 3
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Get 3 for the price of 2 total price</returns>
        private static decimal _CalculateGET3FOR2(this Product product)
        {
            var outOfOfferItems = product.Count % 3; //get items which falls under less than 3 category
            var priceAfterOffer = ((product.Count - outOfOfferItems) / 3) * (product.PricePerItem * 2); //calculate cost for multiples of 3 items
            var priceForOutOfOfferItems = outOfOfferItems * product.PricePerItem; //get cost for less than 3 items
            return priceAfterOffer + priceForOutOfOfferItems; //add to get total cost
        }
    }
}
