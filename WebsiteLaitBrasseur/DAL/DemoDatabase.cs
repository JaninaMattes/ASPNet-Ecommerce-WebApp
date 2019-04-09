using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteLaitBrasseur.Models;
using System.ComponentModel;

namespace WebsiteLaitBrasseur.DAL
{

    // this dummy class is used in place of a database to develop the 'look and feel' of a site 
    // without the need for a DB connection
    public class DemoDatabase
    {
        // this dummy content describes the products and will be exhanged later with real values
        const string Lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        const string ShortLorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        private Models.DetailPage[] product_Details;

        // new instance for our demo database that contains all information for dummy products shown in the overview and detail page
        public DemoDatabase()
        {
            int id = 0;
            product_Details = new Models.DetailPage[] {
                CreateDummyDetailData(id++, "Blue Cheese de Avignón", "Cheese and Aimée", "Cheese", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTB3m0Fjufuen-OfO3DocJJmsCvsWXFRI_Z8ivctwfyQgeT-RQL", "available"),
                CreateDummyDetailData(id++, "Brie de Meaux", "Cheese and Aimée", "Cheese", 239.00, 1, 11.95, 11.95, "https://cdn.pixabay.com/photo/2016/01/19/16/57/cheese-1149471__340.jpg", "available"),
                CreateDummyDetailData(id++, "Camember de Normandie", "Cheese and Aimée", "Cheese", 239.00, 1, 14.95, 14.95, "http://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2013/12/WGC-Cheese-Board-2-copy-2.jpg", "available"),
                CreateDummyDetailData(id++, "Maroilles Hard Cheese", "Cheese and Aimée", "Cheese", 239.00, 1, 12.95, 12.95, "https://iowagirleats-iowagirleats.netdna-ssl.com/wp-content/uploads/2014/11/How-To-Make-A-Cheese-Plate-For-Entertaining-iowagirleats-12_mini.jpg", "available"),
                CreateDummyDetailData(id++, "Ceré de Pont-l'Évêque", "Cheese and Aimée", "Cheese", 239.00, 1, 8.95, 8.95, "https://www.archanaskitchen.com/images/archanaskitchen/World_appetizer/Assorted_Cheese_Platter_Served_With_Fruits_Crackers.jpg", "available"),
                CreateDummyDetailData(id++, "Roquefort de Meaux", "Cheese and Aimée", "Cheese", 239.00, 1, 14.95, 14.95, "https://img.taste.com.au/i548fx3B/taste/2016/11/mixed-cheese-platter-with-honey-walnuts-78043-1.jpeg", "available"),
                CreateDummyDetailData(id++, "Epoisses Rinsed", "Lait Brasseur", "Cheese", 239.00, 1, 14.95, 14.95, "https://cdn.shopify.com/s/files/1/1154/8424/products/image_49bdc53d-8be0-4710-9ed1-3cfb2d405cdd.jpg?v=1536369395", "available"),
                CreateDummyDetailData(id++, "Munster Old", "Lait Brasseur", "Cheese", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTExxgnQgZr5OfiZyWT1rnki64quU-erZo6d6vrU8dtiRPtxyvTCA", "available"),
                CreateDummyDetailData(id++, "Reblochon Traditionalé", "Lait Brasseur", "Cheese", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2-LDAbkYXagj8sXyyKHkZY9SPhmZ-9eYRZXhg3CsKRBClohTo", "available"),
                CreateDummyDetailData(id++, "Mont d'Or Cheese", "Lait Brasseur", "Cheese", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnRuWi1SM_I3aEr6BPOA1UPUU7cy4W3UUsawwkNzzp5PYw2x4B", "available"),
                CreateDummyDetailData(id++, "Ossau Iray Soft", "Lait Brasseur", "Cheese", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrcmoCow8eaZeF1CAuO8IkCM9BKTlEsu-WaF39H8hXGdSp71Vglg", "available"),
                CreateDummyDetailData(id++, "Brie de Meaux", "Lait Brasseur", "Cheese", 239.00, 1, 14.95, 14.95, "https://i2.wp.com/chocolateandmarrow.com/wp-content/uploads/2016/05/How-To-Make-A-Meat-And-Cheese-Platter-5.jpg", "available") };

        }

        // method to create dummy detail data 
        private Models.DetailPage CreateDummyDetailData(int id, string productName, string producer, string productType, double unit, int quantity, double price, double total, string imageUrl, string available)
        {
            Models.DetailPage destination = new Models.DetailPage() { Id = id, ProductName = productName, ProducerName = producer, ShortDescription = ShortLorem, LongDescription = Lorem, ProductType = productType, Unit = (decimal)unit, Quantity = quantity, Price = (decimal)price, TotalAmount = (decimal)total, ImagePath = imageUrl, Available = available };
            return destination;
        }

        // method returns all products that are available in the database in an array
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.DetailPage[] GetProducts()
        {
            return product_Details;
        }

        // method returns all products filtered by id and is used to get the correct 
        //product when navigating to detail page
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.DetailPage GetProduct(int id)
        {
            return Array.Find(product_Details, d => { return d.Id == id; });
        }

        // method returns a specific product filtered for its product name
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.DetailPage GetProduct(string name)
        {
            return Array.Find(product_Details, d => { return d.ProductName == name; });
        }

        // method returns all products filtered for their type
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.DetailPage[] GetProducts(string type)
        {
            List<DetailPage> productTypes = new List<DetailPage>();
            for(int i = 0; i<= GetProducts().Length; i++)
            {
                productTypes.Add(Array.Find(product_Details, d => { return d.ProductType == type; }));
            }
            return productTypes.ToArray();
        }

        // method to delete a product out of a list of products
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void DeleteProduct(int id)
        {
            product_Details = product_Details.Where(d => d.Id != id).ToArray();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateProductBy(int id)
        {
        }
    }
}