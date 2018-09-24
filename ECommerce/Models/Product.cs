using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Id is Required")]
        public int Product_id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is Required")]
        public string Product_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Price is Required")]
        public decimal Price { get; set; }
        public decimal Offer { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Manufacturing Date is Required")]
        public DateTime Mfg_date { get; set; }
        public DateTime Expiry_date { get; set; }
        public int Best_before_months { get; set; }
        public int Product_category_id { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}