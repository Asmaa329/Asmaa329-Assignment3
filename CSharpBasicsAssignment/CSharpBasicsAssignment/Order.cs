using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasicsAssignment
{
    public class Order
    {
        public int OrderId;
        public string CustomerName;
        public int Quantity;
        public decimal UnitPrice;
        public decimal TotalPrice;
        public bool IsPaid;
        public double DiscountPercent;
        public string ShippingCity;
        public char Priority;
        public long ItemCode;

        public void CalculateTotal()
        {
            TotalPrice = (decimal)Quantity * UnitPrice * (1m - (decimal)(DiscountPercent / 100.0));
        }

        public void PrintSummary()
        {
            Console.WriteLine($"Order #{OrderId} & Customer {CustomerName} & Total {TotalPrice:C} & Paid {IsPaid}");
        }
    }
}
