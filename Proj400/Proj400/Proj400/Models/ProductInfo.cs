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
        [Display(Name = "Product Name")]
        public string product_Name { get; set; }
        [Required(ErrorMessage = "Please specify a Category")]
        [Display(Name = "Product Category")]
        public string product_Category { get; set; }
        [Display(Name = "Product Type")]
        public string product_Type { get; set; }
        [Display(Name = "Product Brand")]
        public string product_Brand { get; set; }
        [Display(Name = "Product Color")]
        public string product_Color { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a Description")]
        [Display(Name = "Product Description")]
        public string product_Desc { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a price")]
        [Display(Name = "Product Price")]
        public decimal product_Price { get; set; }
        [Display(Name = "Product Quantity")]
        public int product_Quantity { get; set; }
    
        public byte[] Image_Data { get; set; }
        public string Image_Mime_Type { get; set; }
    }
}
