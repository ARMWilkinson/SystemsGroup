using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spot.Services.Models
{
    public class CartProduct : Spot.Data.Products
    {
        public int Quantity { get; set; }
    }
}
