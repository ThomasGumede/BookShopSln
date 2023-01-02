using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class CartVM
    {
        public IEnumerable<CartItem> List { get; set; } = null!;
        public decimal Subtotal { get; set; }
        // public int Count { get; set; }

    }
}