using PizzaPieShop.Models;

namespace PizzaPieShop.IRepositories
{
    public interface IOrderRepository
    { 
        void CreateOrder(Order order);
    }
}
