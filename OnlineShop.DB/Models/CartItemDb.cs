using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DB.Models
{
    public class CartItemDb
    {
        public Guid Id { get; set; }
        public ProductDB Product { get; set; }
        public int Amount { get; set; }
    }
}
