using PizzaPieShop.IRepositories;
using PizzaPieShop.Models;

namespace PizzaPieShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieShopDbContext DbContext;
        public CategoryRepository(PieShopDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public IEnumerable<Category> AllCategories => DbContext.Categories.OrderBy(p => p.CategoryName);
    } 
}
