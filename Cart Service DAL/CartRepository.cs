using Cart_Service_BLL;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Service_DAL
{
    public class CartRepository : ICartRepository
    {
        private readonly string _connectionString;
        public CartRepository()
        {
            _connectionString = "CartDb.db";
        }

        public void AddCart(Cart cart)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Cart>("carts");

                col.Insert(cart);
            }
        }

        public void AddCartItem(Guid cartId, Item item)
        {
            var cart = GetCartInfo(cartId);

            cart.Items.Add(item);

            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Cart>("carts");

                col.Update(cart);
            }
        }

        public void DeleteCartItem(Guid cartId, int itemId)
        {
            var cart = GetCartInfo(cartId);

            var item = cart.Items.Find(x => x.Id == itemId);

            cart.Items.Remove(item);

            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Cart>("carts");

                col.Update(cart);
            }
        }

        public Cart GetCartInfo(Guid id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Cart>("carts");

                var results = col.Query().Where(x => x.Id == id);

                return results.SingleOrDefault();
            }
        }

        public IEnumerable<Item> GetCartInfoV2(Guid id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Cart>("carts");

                var results = col.Query().Where(x => x.Id == id).SingleOrDefault();

                return results.Items;
            }
        }
    }
}
