using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Proj400.Models
{
    public class ProductInfo
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int product_ID { get; set; }
        [Required(ErrorMessage = "Please enter a Product Name")]
        public string product_Name { get; set; }
        [Required(ErrorMessage = "Please specify a Category")]
        public string product_Category { get; set; }
        public string product_Type { get; set; }
        public string product_Brand { get; set; }
        public string product_Color { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a Description")]
        public string product_Desc { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a price")]
        public decimal product_Price { get; set; }
        public int product_Quantity { get; set; }
    }
}
