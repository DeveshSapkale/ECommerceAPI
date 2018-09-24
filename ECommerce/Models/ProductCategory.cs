using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductCategory
    {
        [Key]
        public int Product_category_id { get; set; }
        public string Category_name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}