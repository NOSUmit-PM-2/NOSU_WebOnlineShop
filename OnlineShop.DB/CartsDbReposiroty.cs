using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DB
{
    public class CartsDbReposiroty : ICartsDbReposiroty
    {
        readonly DatabaseContext databaseContext;

        public CartsDbReposiroty(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(ProductDB product, int userId)
        {
            var currentCart = TryGetByUserId(userId);

            if (currentCart == null)
            {
                var newCart = new CartDb();
                newCart.Id = Guid.NewGuid();
                newCart.UserId = userId;
                newCart.CartItems = new List<CartItemDb>();
                newCart.CartItems.Add(AddItem(product));
                databaseContext.CartDbs.Add(newCart);
            }
            else
            {
                var currentCartItem = currentCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);
                if (currentCartItem == null)
                {
                    currentCart.CartItems.Add(AddItem(product));
                }
                else
                {
                    currentCartItem.Amount += 1;
                }
            }
            databaseContext.SaveChangesAsync();

        }

        // Тут непонятно что такое V не успел разобраться
        public void DecreaseCountProduct(Guid productId, int v)
        {
            var currentCart = TryGetByUserId(v);
            var currentCartItem = currentCart.CartItems.FirstOrDefault(x => x.Product.Id == productId);
            if (currentCartItem != null)
            {
                currentCartItem.Amount -= 1;
                if (currentCartItem.Amount == 0)
                {
                    currentCart.CartItems.Remove(currentCartItem);
                }
            }
            databaseContext.SaveChangesAsync();
        }

        public void IncreaseCountProduct(Guid productId, int userId)
        {
            var currentCart = TryGetByUserId(userId);
            var currentCartItem = currentCart.CartItems.FirstOrDefault(x => x.Product.Id == productId);
            if (currentCartItem != null)
            {
                currentCartItem.Amount += 1;
            }
            databaseContext.SaveChangesAsync();
        }

        public CartDb TryGetByUserId(int id)
        {
            return databaseContext.CartDbs.FirstOrDefault(cart => cart.UserId == id);
        }

        CartItemDb AddItem(ProductDB product)
        {
            CartItemDb item = new CartItemDb();
            item.Id = Guid.NewGuid();
            item.Product = product;
            item.Amount = 1;
            return item;
        }
    }
}
