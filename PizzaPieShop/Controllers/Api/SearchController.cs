using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPieShop.IRepositories;
using PizzaPieShop.Models;

namespace PizzaPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository; 
        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }  
        [HttpGet]//https://localhost:7188/api/search
        public IActionResult GetAll()
        {
            var allPies = _pieRepository.AllPies.ToList();
            return Ok(allPies);
        } 
        [HttpGet("{id}")]//https://localhost:7188/api/search/7
        public IActionResult GetById(int id)
        {
            if (!_pieRepository.AllPies.Any(p => p.PieId == id))
                return NotFound();
            //return new JsonResult(_pieRepository.AllPies.Where(p =>p.PieId == id);
            return Ok(_pieRepository.AllPies.Where(p => p.PieId == id));
        }

        [HttpPost]//https://localhost:7188/api/search
        // send in body as row json "map"
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>(); 
            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _pieRepository.SearchPies(searchQuery);
            }
            return new JsonResult(pies);
        }

    }
}
