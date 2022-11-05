using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Cart_Service_BLL
{
    public interface ICartRepository
    {
        Cart GetCartInfo(Guid id);
        void AddCart(Cart cart);
        void AddCartItem(Guid cartId, Item item);
        void DeleteCartItem(Guid cartId, int itemId);
        IEnumerable<Item> GetCartInfoV2(Guid id);
    }
}
