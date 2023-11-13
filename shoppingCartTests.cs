using System;
using NUnit.Framework;
using shoppingCart.Fundamentals;

namespace shoppingCart.UnitTests
{

    [TestFixture]
    public class ShoppingCartTests
    {
        private ShoppingCart cart

        [SetUp]
        public void SetUp()
        {
            cart = new ShoppingCart();
        }

        [Test]
        public void Constructor_CheckItemsDictionaryIsEmpty_ReturnsTrue()
        {

            // Act
            bool isItemsDictionaryEmpty = cart.Items.Count == 0;

            // Assert
            Assert.IsTrue(isItemsDictionaryEmpty);
        }

        [Test]
        public void Constructor_CheckTaxRateIs0_07_ReturnsTrue()
        {

            // Act
            decimal expectedTaxRate = 0.07M;

            // Assert
            Assert.AreEqual(expectedTaxRate, cart.TaxRate);
        }

        [Test]
        public void Constructor_CheckValidCoupons_10Or20Percent_ReturnsTrue()
        {

            // Act
            decimal expectedSave10Discount = 0.1M;
            decimal expectedOff20Discount = 0.2M;

            // Assert
            Assert.AreEqual(expectedSave10Discount, cart.ValidCoupons["SAVE10"]);
            Assert.AreEqual(expectedOff20Discount, cart.ValidCoupons["OFF20"]);
        }

        [Test]
        public void AddItem_ShouldAddItemWithCorrectNameandPrice()
        {

            //Act
            cart.AddItem("bread", 1.50);

            //Assert
            Assert.AreEqual(1.50, cart.Items["bread"]);
            Assert.IsTrue(cart.Items.ContainsKey("bread"));
        }

        [Test]
        public void CalculateSubtotal_ShouldCalcualteCorrectly()
        {
            //Act
            cart.CalculateSubtotal("bread", 1.50);

            //Assert
            Assert.AreEqual(1.50, cart.CalculateSubtotal());
        }

        [Test]
        public void ApplyTax_ShouldApplyTaxCorrectly()
        {
            //Arrange
            cart.AddItem("bread", 1.50);

            //Act
            decimal subtotal = cart.CalculateSubtotal();
            decimal totalAfterTax = cart.ApplyTax(subtotal);

            //Assert
            Assert.AreEqual(subtotal * 1.07, totalAfterTax);
        }

        [Test]
        public void ApplyCoupon_ShouldModifySubtotalCorrectly()
        {
            //Arrange
            cart.AddItem("bread", 1.50);

            //Act
            decimal originalSubtotal = cart.CalculateSubtotal();
            cart.ApplyCoupon("SAVE10");
            decimal modifiedSubtotal = cart.CalculateSubtotal();

            //Assert
            Assert.AreEqual(originalSubtotal * (1 - 0.1M), modifiedSubtotal);
        }

        [Test]
        public void CalculateTotal_ShouldCalculateFinalTotal()
        {
            //Arrange
            cart.AddItem("bread", 1.50);

            //Act
            decimal subtotal = cart.CalculateSubtotal();
            cart.ApplyCoupon("SAVE10");
            decimal totalAfterTax = cart.CalculateSubtotal();

            //Assert
            Assert.AreEqual(subtotal * 1.07M, * (1 - 0.1M), totalAfterTax);
        }
    }
    
}