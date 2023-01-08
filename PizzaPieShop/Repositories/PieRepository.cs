using Microsoft.EntityFrameworkCore;
using PizzaPieShop.IRepositories;
using PizzaPieShop.Models;
using System.Xml.Linq;

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
                return context.Pies.Include(c => c.Category)
                                    .Select(x => new Pie 
                                            { 
                                                Name=x.Name,
                                                PieId=x.PieId,
                                                InStock=x.InStock,
                                                CategoryId=x.CategoryId,
                                                ImageUrl=x.ImageUrl,
                                                ImageThumbnailUrl=x.ImageThumbnailUrl,
                                                IsPieOfTheWeek=x.IsPieOfTheWeek,
                                                Price=x.Price,
                                                LongDescription=x.LongDescription,
                                                ShortDescription=x.ShortDescription,
                                                AllergyInformation=x.AllergyInformation,
                                                Category= 
                                                new Category 
                                                    {
                                                       CategoryName= x.Category.CategoryName,
                                                       CategoryId=x.Category.CategoryId ,
                                                       Description=x.Category.Description  
                                                    }
                                    }).AsEnumerable<Pie>();

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
