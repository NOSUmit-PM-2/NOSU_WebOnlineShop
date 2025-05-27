using OnlineShop.DB;
using WebApplicationShopOnline.Models;

namespace WebApplicationShopOnline.Helpers
{
    public class Mapping
    {
        public static Product ToProduct(ProductDB product) 
        {
            return new Product
            {
                Id = product.Id,   
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                PathPicture = product.PathPicture
            };
        }

        public static ProductDB ToProductDB(Product product)
        {
            return new ProductDB
            {
                Id = product.Id,   
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                PathPicture = product.PathPicture
            };
        }

        public static List<Product> ToProductsList(List<ProductDB> productDBs)
        {
            List<Product> products = new List<Product>();
            foreach(var product in productDBs)
                products.Add(ToProduct(product));
            return products;
        }

        public static List<ProductDB> ToProductDBsList(List<Product> products)
        {
            List<ProductDB> productDBs = new List<ProductDB>();
            foreach (var product in products)
                productDBs.Add(ToProductDB(product));
            return productDBs;
        }
    }
}
