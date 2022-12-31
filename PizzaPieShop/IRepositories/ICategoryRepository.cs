using PizzaPieShop.Models;

namespace PizzaPieShop.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
