using AnimalsWebApplication.Models;
using AnimalsWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _irepository;

        public AdminController(IRepository _irepository)
        {
            this._irepository = _irepository;
        }
        public IActionResult Index(string Category)
        {
            return View(_irepository.GetAnimalsByCategory(Category));
        }

        public IActionResult Delete(int id)
        {
            _irepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animal = _irepository.FindAnimal(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _irepository.Categories();
                return View(animal);
            }
                _irepository.EditAnimal(animal);
                return RedirectToAction("Index", null);
        }
        [HttpGet]
        public IActionResult NewAnimal()
        {
            ViewBag.Categories = _irepository.Categories();
            return View(new Animal());
        }

        [HttpPost]
        public IActionResult NewAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _irepository.Categories();
                return View(animal);
            }
            _irepository.AddNewAnimal(animal.Name, animal.Age, animal.PictureSrc, animal.Description, animal.CategoryId);
            return RedirectToAction("Index");
        }
    }
}
