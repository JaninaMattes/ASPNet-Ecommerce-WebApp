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
        public string ProductDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Unit { get; set; }
    }
}