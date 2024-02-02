// See https://aka.ms/new-console-template for more information
using ProductCart;

Console.WriteLine("Welcome to shopping cart");

List<string> list = new List<string>()
{
    "Apple",
    "Bananas",
    "Apple",
    "Melons",
    "Melons",
    "Melons",
    "LIMES",
    "LIMES",
    "LIMES",
    "LIMES"
};

var cart = new Cart();
cart.AddToCart(list);

Console.WriteLine(" Name : Quantity : Price : Offer Price");
foreach (var item in cart.CartItems)
{
    Console.WriteLine(item.Name + " : " + item.Count + " : " + item.GetDefaultTotal + " : " + item.GetOfferCost());
}

Console.WriteLine(cart.CostCalculator());
Console.ReadKey();
