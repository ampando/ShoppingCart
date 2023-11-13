using System;
using System.Collections.Generic;

public class ShoppingCart
{
    private Dictionary<string, decimal> items;
    private decimal taxRate;
    private Dictionary<string, decimal> validCoupons;

    public ShoppingCart()
    {
        items = new Dictionary<string, decimal>();
        taxRate = 0.07M;  // 7% tax rate
        validCoupons = new Dictionary<string, decimal>
        {
            {"SAVE10", 0.1M},  // 10% discount
            {"OFF20", 0.2M}    // 20% discount
        };
    }

    public void AddItem(string itemName, decimal price)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] += price;
        }
        else
        {
            items[itemName] = price;
        }
    }

    public decimal CalculateSubtotal()
    {
        decimal subtotal = 0;
        foreach (var item in items)
        {
            subtotal += item.Value;
        }
        return subtotal;
    }

    public decimal ApplyTax(decimal subtotal)
    {
        return subtotal * (1 + taxRate);
    }

    public decimal ApplyCoupon(decimal subtotal, string couponCode)
    {
        if (validCoupons.TryGetValue(couponCode, out decimal discountRate))
        {
            return subtotal - discountRate;
        }
        return subtotal;
    }

    public decimal CalculateTotal(string couponCode = null)
    {
        decimal subtotal = CalculateSubtotal();
        if (!string.IsNullOrEmpty(couponCode))
        {
            subtotal = ApplyCoupon(subtotal, couponCode);
        }
        decimal total = ApplyTax(subtotal);
        return Math.Round(total, 2);
    }
}

public class Program
{
    public static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        cart.AddItem("Laptop", 1000M);
        cart.AddItem("Headphones", 200M);
        decimal finalTotal = cart.CalculateTotal("SAVE10");

        Console.WriteLine($"Final Total: {finalTotal:C}");
    }
}
