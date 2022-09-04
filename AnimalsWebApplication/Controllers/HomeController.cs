using AnimalsWebApplication.Data;
using AnimalsWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //private AnimalContext _context;
        //private MyRepository _myRepository;
        private IRepository _irepository;


        public HomeController(IRepository _irepository)
        {
            this._irepository = _irepository;
        }

        public IActionResult Index()
        {
            return View(_irepository.MostComments());
        }
        
    }
}
