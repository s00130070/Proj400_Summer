using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj400.Models
{
    public class OrderInfo
    {
        [Key]
        public int order_ID { get; set; }
        public string username { get; set; }
        public string contact_Number { get; set; }
        public DateTime order_Date { get; set; }
        public int user_ID { get; set; }

        public int order_Quantity { get; set; }
        public string order_Status { get; set; }
        public int product_ID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Name")]
        public string shipping_ShipName { get; set; }
        [Display(Name = "Line 1")]
        public string shipping_Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string shipping_Line2 { get; set; }
        [Display(Name = "Line 3")]
        public string shipping_Line3 { get; set; }
        public string shipping_City { get; set; }

        public string shipping_State { get; set; }

        [Required(ErrorMessage = "Please enter country")]
        public string shipping_Country { get; set; }
        public string shipping_Postcode { get; set; }
        public bool shiping_Wrapped { get; set; }
    }
}