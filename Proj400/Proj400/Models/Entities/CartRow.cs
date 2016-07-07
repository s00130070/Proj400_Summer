using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj400.Models.Entities
{
    public class CartRow
    {
        public ProductInfo Product { get; set; }
        public int Quantity { get; set; }
    }
}