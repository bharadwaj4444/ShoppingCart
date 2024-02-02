namespace ProductCart
{
    /// <summary>
    /// Cart deletion is not implemented
    /// </summary>
    public class Cart
    {
        public List<Product> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<Product>();
        }

        /// <summary>
        /// Add item list to cart
        /// </summary>
        /// <param name="items"></param>
        public void AddToCart(List<string> items)
        {
            foreach (var item in items)
            {
                var result = AddToCart(item);
            }
        }

        /// <summary>
        /// Add single item to cart
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item added successfully</returns>
        public bool AddToCart(string item)
        {
            try
            {
                var cartItem = CartItems.FirstOrDefault(ci => ci.Name.ToUpper() == item.ToUpper());
                if (cartItem == null)
                {
                    cartItem = _GetProduct(item);
                    CartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Count++;
                }
                return true;
            }
            catch (Exception ex)
            {
                //exception not taken care
                return false;
            }
        }

        /// <summary>
        /// Calculate the cost of the cart
        /// </summary>
        /// <returns></returns>
        public decimal CostCalculator()
        {
            decimal cost = 0;
            foreach (var item in CartItems)
            {
                if (item.Offer != Offers.OfferType.NOOFFER)
                {
                    cost += item.GetOfferCost();//offer value calculated
                }
                else cost += item.GetDefaultTotal;//if no offer get default total
            }
            return cost;
        }

        /// <summary>
        /// Get product type based on the item available
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="Exception">If item not found in the inventory/exception>
        private Product _GetProduct(string item)
        {
            var pricePerItem = _GetPricePerItem(item);
            switch (item.ToUpper())
            {
                case "APPLE": return new Product("Apple", pricePerItem); //default no offer
                case "BANANAS": return new Product("Banana", pricePerItem); //default no offer
                case "MELONS": return new Product("Melons", pricePerItem, Offers.OfferType.BOGO); //specifying the offer type
                case "LIMES": return new Product("Limes", pricePerItem, Offers.OfferType.GET3FOR2); //specifying the offer type
                default: throw new Exception("Item not found");
            }
        }

        /// <summary>
        /// Price per item is pre-defined, if no item found then cost is 0.00
        /// </summary>
        /// <param name="item"></param>
        /// <returns>per item cost in decimal</returns>
        private decimal _GetPricePerItem(string item)
        {
            switch (item.ToUpper())
            {
                case "APPLE": return 0.35M;
                case "BANANAS": return 0.20M;
                case "MELONS": return 0.50M;
                case "LIMES": return 0.15M;
                default: return 0.00M;
            }
        }
    }
}
