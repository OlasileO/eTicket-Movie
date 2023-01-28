using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext dbContext { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            dbContext = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession session= serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<AppDbContext>();

            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }
        public void AddItemToCart(Movie movie)
        {
            var shoppingcart = dbContext.ShoppingCartItems.FirstOrDefault(n => n.movie.Id == movie.Id
             && n.ShoppingCartId == ShoppingCartId);

            if(shoppingcart == null)
            {
                shoppingcart = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    movie = movie,
                    Amount = 1,

                };
                dbContext.ShoppingCartItems.Add(shoppingcart);
            }
            else
            {
                shoppingcart.Amount++;
            }
            dbContext.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCart = dbContext.ShoppingCartItems.FirstOrDefault(n => n.movie.Id==movie.Id
            && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCart != null)
            {
                if (shoppingCart.Amount > 1)
                {
                    shoppingCart.Amount--;
                }
                else
                {
                    dbContext.ShoppingCartItems.Remove(shoppingCart);
                }
                dbContext.SaveChanges();
            }
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = dbContext.ShoppingCartItems.Where
                (n => n.ShoppingCartId == ShoppingCartId).Include(n => n.movie).ToList());
        }

        public double GetShoppingcartTotal() => dbContext.ShoppingCartItems.Where(n => n.ShoppingCartId
        == ShoppingCartId).Select(n => n.movie.Price * n.Amount).Sum();

        public async Task ClearshoppingCartAsync()
        {
            var items = await dbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            dbContext.ShoppingCartItems.RemoveRange(items);
            await dbContext.SaveChangesAsync();
        }
    }
}
