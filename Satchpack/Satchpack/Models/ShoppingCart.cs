using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Satchpack.Domain.Entities;

namespace Satchpack.Models
{
    public class ShoppingCart
    {
        public List<OrderItem> OrderItems { get; set; }
        public int ItemCount
        {
            get
            {
                return OrderItems.Sum(item => item.Quantity);
            }
        }
        public double SubtotalCost
        {
            get
            {
                if (OrderItems.Count != 0 && OrderItems.All(x => x.Product != null))
                    return OrderItems.Sum(x => x.Product.Price * (double)x.Quantity);
                else
                    return 0;
            }
        }
        public double TotalCost
        {
            get
            {
                double total = 0;
                if (ItemCount > 0)
                    total = SubtotalCost + ShippingCost;
                return total;
            }
        }
        public double ShippingCost { get; private set; }

        public ShoppingCart()
        {
            OrderItems = new List<OrderItem>();
            ShippingCost = 10.00;
        }
    }
}