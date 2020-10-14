using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int UPC { get; set; }
        [Required]
        [Range(0,10000)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}