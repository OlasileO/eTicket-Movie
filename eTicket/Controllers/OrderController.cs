using eTicket.Data.Cart;
using eTicket.Data.Service;
using eTicket.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eTicket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMovieService movieService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrderService orderService;
        public OrderController(IMovieService _movieService, ShoppingCart _shoppingCart, IOrderService _orderService)
        {
            movieService = _movieService;
            shoppingCart = _shoppingCart;
            orderService = _orderService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var allorders = await orderService.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return View(allorders);
        }
        public IActionResult ShoppingCart()
        {
            var item = shoppingCart.GetShoppingCartItems();
            shoppingCart.shoppingCartItems = item;
            var reponse = new ShoppingCartVM
            {
                shoppingCart= shoppingCart,
                shoppingCartTotal = shoppingCart.GetShoppingcartTotal(),
            };
            return View(reponse);
        }

        public async Task<IActionResult> AddItemToShopCart(int id)
        {
            var movie = await movieService.GetMovieByIdAsync(id);
            if (movie != null)
            {
                shoppingCart.AddItemToCart(movie);
            }
            return RedirectToAction( nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFrmShopCart(int id)
        {
            var movie = await movieService.GetMovieByIdAsync(id);

            if (movie != null)
            {
                shoppingCart.RemoveItemFromCart(movie);
            }
            return RedirectToAction( nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await orderService.StoreOrderAysnc(items, userId, userEmailAddress);
            await shoppingCart.ClearshoppingCartAsync();
            return View("orderCompleted");
        }
    }
}
