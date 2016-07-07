using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Proj400.Models.Entities
{
    public class ProductsList
    {
        public IEnumerable<ProductInfo> ProductInfo { get; set;}
        public PagingInfo PagingInfo { get; set; }
    }
}