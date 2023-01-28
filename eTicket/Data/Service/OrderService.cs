using eTicket.Data.Cart;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Service
{
    public class OrderService:IOrderService
    {
        private readonly AppDbContext dbContext;
        public OrderService(AppDbContext contex)
        {
            dbContext= contex;

        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await dbContext.Orders.Include(n => n.orderItems).ThenInclude( n=> n.movie).Include(n => n.User).ToListAsync(); 
            if(userRole != "admin")
            {
                orders = orders.Where( n=> n.UserId== userId).ToList(); 
            }
            return orders;  
        }

        public async Task StoreOrderAysnc(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
            };
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderitem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.movie.Id,
                    OrderId = order.Id,
                    Price = item.movie.Price,
                };
                await dbContext.OrderItems.AddAsync(orderitem);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
