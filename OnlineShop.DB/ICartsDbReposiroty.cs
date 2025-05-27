using OnlineShop.DB.Models;

namespace OnlineShop.DB
{
    public interface ICartsDbReposiroty
    {
        CartDb TryGetByUserId(int id);
        void Add(ProductDB product, int userId);
        void IncreaseCountProduct(Guid productId, int userId);
        void DecreaseCountProduct(Guid productId, int v);
    }
}
