using ProductCart;

namespace ProductCartTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        [DataRow("Apple")]
        [DataRow("Bananas")]
        [DataRow("Melons")]
        [DataRow("Limes")]
        public void TestAddToCartTrue(string item)
        {
            var cart = new Cart();
            var result = cart.AddToCart(item);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Grapes")]
        public void TestAddToCartFalse(string item)
        {
            var cart = new Cart();
            var result = cart.AddToCart(item);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("Apple")]
        [DataRow("Bananas")]
        [DataRow("Melons")]
        [DataRow("Limes")]
        public void TestCostCalculator(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreNotEqual(0.0M, result);
        }

        [TestMethod]
        [DataRow("Apple")]
        public void TestCostCalculatorApple(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.7M, result);
        }

        [TestMethod]
        [DataRow("Bananas")]
        public void TestCostCalculatorBanana(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.40M, result);
        }

        [TestMethod]
        [DataRow("Melons")]
        public void TestCostCalculatorMelons(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.50M, result);
        }

        [TestMethod]
        [DataRow("Limes")]
        public void TestCostCalculatorLimes(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            cart.AddToCart(item);
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.30M, result);
        }

        [TestMethod]
        [DataRow("Melons")]
        public void TestCostCalculatorMelonsBOGOForSingleItem(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.25M, result);
        }

        [TestMethod]
        [DataRow("Limes")]
        public void TestCostCalculatorLimesGET3FOR2On2Items(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.30M, result);
        }

        [TestMethod]
        [DataRow("Limes")]
        public void TestCostCalculatorLimesGET3FOR2On4Item(string item)
        {
            var cart = new Cart();
            cart.AddToCart(item);
            cart.AddToCart(item);
            cart.AddToCart(item);
            cart.AddToCart(item);
            var result = cart.CostCalculator();
            Assert.AreEqual(0.45M, result);
        }
    }
}
