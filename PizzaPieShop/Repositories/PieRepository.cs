using Microsoft.EntityFrameworkCore;
using PizzaPieShop.IRepositories;
using PizzaPieShop.Models;

namespace PizzaPieShop.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext context; 
        public PieRepository(PieShopDbContext context)
        {
            this.context = context;
        } 
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return context.Pies.Include(c => c.Category);
            }
        } 
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        } 
        public Pie? GetPieById(int pieId)
        {
            return context.Pies.FirstOrDefault(p => p.PieId == pieId);
        } 
        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return this.context.Pies.Where(a => a.Name.Contains(searchQuery));
        }
    }
}
