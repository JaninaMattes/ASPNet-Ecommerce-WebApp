using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    //
    // this dummy class is used in place of a database to develop the 'look and feel' of a site 
    // without the need for a DB connection
    public class DemoDatabase
    {
        const string Lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        const string ShortLorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        private Models.DetailPage[] product_Details;

        public DemoDatabase()
        {
            int id = 0;
            product_Details = new Models.DetailPage[] {
                CreateDummyDetailData(id++, "Blue Cheese de Avignón", "Cheese and Aimée", 239.00, 1, 14.95, 14.95, "https://media.self.com/photos/58334d903ab10950129052bc/4:3/w_728,c_limit/cheese-plate.jpg"),
                CreateDummyDetailData(id++, "Brie de Meaux", "Cheese and Aimée", 239.00, 1, 14.95, 14.95, "https://cdn.pixabay.com/photo/2016/01/19/16/57/cheese-1149471__340.jpg"),
                CreateDummyDetailData(id++, "Camember de Normandie", "Cheese and Aimée", 239.00, 1, 14.95, 14.95, "http://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2013/12/WGC-Cheese-Board-2-copy-2.jpg"),
                CreateDummyDetailData(id++, "Maroilles Hard Cheese", "Cheese and Aimée", 239.00, 1, 14.95, 14.95, "https://presidentcheese-y0leynmj.netdna-ssl.com/wp-content/uploads/2017/07/Summer-Cheese-Plate.jpg"),
                CreateDummyDetailData(id++, "Ceré de Pont-l'Évêque", "Cheese and Aimée", 239.00, 1, 14.95, 14.95, "https://www.archanaskitchen.com/images/archanaskitchen/World_appetizer/Assorted_Cheese_Platter_Served_With_Fruits_Crackers.jpg"),
                CreateDummyDetailData(id++, "Roquefort de Meaux", "Cheese and Aimée", 239.00, 1, 14.95, 14.95, "https://img.taste.com.au/i548fx3B/taste/2016/11/mixed-cheese-platter-with-honey-walnuts-78043-1.jpeg"),
                CreateDummyDetailData(id++, "Epoisses Rinsed", "Lait Brasseur", 239.00, 1, 14.95, 14.95, "https://cdn.shopify.com/s/files/1/1154/8424/products/image_49bdc53d-8be0-4710-9ed1-3cfb2d405cdd.jpg?v=1536369395"),
                CreateDummyDetailData(id++, "Munster Old", "Lait Brasseur", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTExxgnQgZr5OfiZyWT1rnki64quU-erZo6d6vrU8dtiRPtxyvTCA"),
                CreateDummyDetailData(id++, "Reblochon Traditionalé", "Lait Brasseur", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2-LDAbkYXagj8sXyyKHkZY9SPhmZ-9eYRZXhg3CsKRBClohTo"),
                CreateDummyDetailData(id++, "Mont d'Or Cheese", "Lait Brasseur", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnRuWi1SM_I3aEr6BPOA1UPUU7cy4W3UUsawwkNzzp5PYw2x4B"),
                CreateDummyDetailData(id++, "Ossau Iray Soft", "Lait Brasseur", 239.00, 1, 14.95, 14.95, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrcmoCow8eaZeF1CAuO8IkCM9BKTlEsu-WaF39H8hXGdSp71Vglg"),
                CreateDummyDetailData(id++, "Brie de Meaux", "Lait Brasseur", 239.00, 1, 14.95, 14.95, "https://i2.wp.com/chocolateandmarrow.com/wp-content/uploads/2016/05/How-To-Make-A-Meat-And-Cheese-Platter-5.jpg") };

        }

        private Models.DetailPage CreateDummyDetailData(int id, string productName,  string producer, double unit, int quantity, double price, double total, string imageUrl)
        {

            Models.DetailPage destination = new Models.DetailPage() { Id= id, ProductName= productName, ProducerName= productName, ShortDescription= ShortLorem, LongDescription= Lorem, Unit= (decimal)unit, Quantity= quantity, Price= (decimal)price, TotalAmount= (decimal)total, ImagePath = imageUrl };
            return destination;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.DetailPage[] GetDestinations()
        {
            return product_Details;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Models.DetailPage GetDestinationById(int id)
        {
            return Array.Find(product_Details, d => { return d.Id == id; });
        }
    }
}