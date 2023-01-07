using BethanysPieShop.Models;
using PizzaPieShop.IRepositories;
using PizzaPieShop.Models;

namespace PizzaPieShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PieShopDbContext dbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(PieShopDbContext _dbContext, IShoppingCart shoppingCart)
        {
            dbContext = _dbContext;
            _shoppingCart = shoppingCart;
        } 
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now; 
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal(); 
            order.OrderDetails = new List<OrderDetail>(); 
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            dbContext.Orders.Add(order);

            dbContext.SaveChanges();
        }
    }
}
