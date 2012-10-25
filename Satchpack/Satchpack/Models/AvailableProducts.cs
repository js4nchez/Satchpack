using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Satchpack.Domain.Entities;

namespace Satchpack.Models
{
    public class AvailableProducts
    {
        public List<Inventory> Products { get; set; }
        public AvailableProducts()
        {
            Products = new List<Inventory>();
        }
    }
}