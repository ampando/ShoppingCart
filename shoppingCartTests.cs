using System;
using NUnit.Framework;
using shoppingCart.Fundamentals;

namespace shoppingCart.UnitTests
{

    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void Constructor_CheckItemsDictionaryIsEmpty_ReturnsTrue()
        {
            // Arrange
            ShoppingCart cart = new ShoppingCart();

            // Act
            bool isItemsDictionaryEmpty = cart.Items.Count == 0;

            // Assert
            Assert.IsTrue(isItemsDictionaryEmpty);
        }

        [Test]
        public void Constructor_CheckTaxRateIs0_07_ReturnsTrue()
        {
            // Arrange
            ShoppingCart cart = new ShoppingCart();

            // Act
            decimal expectedTaxRate = 0.07M;

            // Assert
            Assert.AreEqual(expectedTaxRate, cart.TaxRate);
        }

        [Test]
        public void Constructor_CheckValidCoupons_10Or20Percent_ReturnsTrue()
        {
            // Arrange
            ShoppingCart cart = new ShoppingCart();

            // Act
            decimal expectedSave10Discount = 0.1M;
            decimal expectedOff20Discount = 0.2M;

            // Assert
            Assert.AreEqual(expectedSave10Discount, cart.ValidCoupons["SAVE10"]);
            Assert.AreEqual(expectedOff20Discount, cart.ValidCoupons["OFF20"]);
        }
    }
}