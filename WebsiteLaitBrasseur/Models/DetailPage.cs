using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.Models
{
    public class DetailPage
    {
        /// <summary>
        /// Detailpage for a product
        /// </summary>
    
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ProductName { get; set; }
        public string ProducerName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ProductType { get; set; }
        public decimal Unit { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public string Available { get; set; }
    }
}