using Microsoft.AspNetCore.Mvc;
using PizzaPieShop.IRepositories;
using PizzaPieShop.ViewModels;

namespace PizzaPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";

            //return View(_pieRepository.AllPies);

            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesListViewModel);
        }
        public IActionResult Details(int id) //https://localhost:7188/pie/Details/7
        {
            var pie= _pieRepository.GetPieById(id);
            if ( pie==null)
            {
                return NotFound();
            }
            return View (pie);
        }
    }
}