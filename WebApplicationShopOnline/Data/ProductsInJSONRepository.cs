using System.Linq;
using WebApplicationShopOnline.Models;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace WebApplicationShopOnline.Data
{
    public class ProductsInJSONRepository : IProductsRepository
    {
        List<Product> products;

        public ProductsInJSONRepository()
        {
            var jsonString = File.ReadAllText("Data/products.json");
            products = JsonSerializer.Deserialize<List<Product>>(jsonString);

        }

        public void Add(Product product)
        {
            products.Add(product);
            Save();
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(Guid id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public void Updata(Product product)
        {
            var existingProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            existingProduct.PathPicture = product.PathPicture;
            Save();
        }

        void Save()
        {
            string updatedJsonString = JsonSerializer.Serialize(products,
            new JsonSerializerOptions
            {
                WriteIndented = true, // человекочитаемый формат
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText("Data/products.json", updatedJsonString, System.Text.Encoding.UTF8);
        }
    }
}
