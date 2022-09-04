using AnimalsWebApplication.Data;
using AnimalsWebApplication.Models;
using AnimalsWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWebApplication.Controllers
{
    public class CatalogueController : Controller
    {
        private MyRepository _repository;
        private IRepository _irepository;

        public CatalogueController(IRepository _irepository)
        {
            this._irepository = _irepository;
        }

        public IActionResult Index(string Category)
        {
            return View(_irepository.GetAnimalsByCategory(Category));
        }

        public IActionResult Details(int id)
        {
            return View(_irepository.ShowDeteils(id));
        }

        public IActionResult Comment(int id, string commentText)
        {
            _irepository.AddComment(id, commentText);
            _irepository.SaveComment();
            return RedirectToAction("Details", "Catalogue",new { id });
        }
    }
}
