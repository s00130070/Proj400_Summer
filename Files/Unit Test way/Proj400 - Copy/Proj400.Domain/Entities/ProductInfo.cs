using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proj400.Domain.Entities
{
    public class ProductInfo
    {
        [Key]
        public int product_ID { get; set; }
        public string product_Name { get; set; }
        public string product_Category { get; set; }
        public string product_Type { get; set; }
        public string product_Brand { get; set; }
        public string product_Color { get; set; }
        public string product_Desc { get; set; }
        public decimal product_Price { get; set; }
        public int product_Quantity { get; set; }
    }
}
