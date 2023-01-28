using eTicket.Data.Cart;
using eTicket.Models;

namespace eTicket.Data.Service
{
    public interface IOrderService
    {
        Task StoreOrderAysnc(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task <List<Order>> GetOrderByUserIdAndRoleAsync (string userId,string userRole);
    }
}
