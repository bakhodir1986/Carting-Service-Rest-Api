namespace Cart_Service_BLL
{
    public interface ICartService
    {
        void AddCartItem(Guid cartId, Item item);
        void DeleteCartItem(Guid cartId, int itemId);
        Cart GetCartInfo(Guid id);
        IEnumerable<Item> GetCartInfoV2(Guid id);
    }
}