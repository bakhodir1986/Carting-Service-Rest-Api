using Cart_Service_BLL;
using Microsoft.AspNetCore.Mvc;

namespace Carting_Service_Web_Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        //Version 1 - API should support the following actions:
        //Get cart info.
        //Input params: cart unique Key(string).
        //Returns a cart model(cart key + list of cart items).
        //Add item to cart.
        //        Input params: cart unique Key (string) + cart item model.
        //Returns 200 if item was added to the cart. If there was no cart for specified key – creates it. Otherwise returns a corresponding HTTP code.
        //Delete item from cart.
        //Input params: cart unique key (string) and item id (int).
        //Returns 200 if item was deleted, otherwise returns corresponding HTTP code.
        //Version 2 – the same as Version 1 but with the following changes:
        //a.Get cart info.
        //Returns a list of cart items instead of cart model.
        //API documentation. Each API version should have its own documentation.

        [HttpGet("{cartid}/v1")]
        public Cart GetCart([FromRoute] string cartid)
        {
            return cartService.GetCartInfo(new Guid(cartid));
        }

        [HttpPost("{cartid}/items")]
        [Consumes("application/json")]
        public IActionResult AddCartItem([FromRoute] string cartid, [FromBody] Item item)
        {
            if (item == null) return BadRequest(item);

            try
            {
                cartService.AddCartItem(new Guid(cartid), item);
            }
            catch (Exception)
            {
                return BadRequest(item);
            }


            return Ok();
        }

        [HttpDelete("{cartid}/items/{itemid}")]
        public IActionResult DeleteCartItem([FromRoute] string cartid, [FromRoute] int itemid)
        {
            try
            {
                cartService.DeleteCartItem(new Guid(cartid), itemid);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{cartid}/v2")]
        public IEnumerable<Item> GetCartItems([FromRoute] string cartid)
        {
            return cartService.GetCartInfoV2(new Guid(cartid));
        }
    }
}
