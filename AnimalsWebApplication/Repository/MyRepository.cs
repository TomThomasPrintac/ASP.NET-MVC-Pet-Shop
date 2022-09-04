using AnimalsWebApplication.Data;
using AnimalsWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWebApplication.Repository
{
    public class MyRepository : IRepository
    {
        public AnimalContext _context;
        public MyRepository(AnimalContext context)
        {
            _context = context;
        }

        public List<Animal> MostComments()
        {
            return _context.Animals!.Include(c => c.Comments!).OrderByDescending(a => a.Comments!.Count).Take(2).ToList();
        }
        public List<Animal> AllAnimals()
        {
            return _context.Animals!.ToList();
        }
        public List<Animal> GetAnimalsByCategory(string category)
        {
            var animal = _context.Animals!.Where(c => c.Category!.Name == category);
            if (category != null)
            {
                return animal.ToList();
            }
            else
                return AllAnimals();
        }
        public Animal ShowDeteils(int id)
        {
            var animal = _context.Animals!.Include(c => c.Comments!).Single(a => a.AnimalId == id);
            return animal;
        }
        public void SaveComment()
        {
            _context.SaveChanges();
        }
        public void AddComment(int id, string commentText)
        {
            var animal = _context.Animals!.Include(c => c.Comments!).Single(a => a.AnimalId == id);
            if (commentText != null)
            {
                animal.Comments!.Add(new Comment { CommentText = commentText });
            }
        }
        public void Delete(int id)
        {
            var animal = _context.Animals!.Single(a => a.AnimalId == id);
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }
        public Animal FindAnimal(int id)
        {
            var currentAnimal = _context.Animals!.Single(a => a.AnimalId == id);
            return currentAnimal;
        }
        public void EditAnimal(Animal animal)
        {
            _context.Animals!.Update(animal);
            _context.SaveChanges();
        }
        public void AddNewAnimal(string _name, int _age, string _pictureSrc, string _description, int _categoryId)
        {
            var allAnimals = _context.Animals!.ToArray();
            var id = allAnimals[allAnimals.Length - 1].AnimalId + 1;

            var newAnimal = new Animal { Name = _name, Age = _age, PictureSrc = _pictureSrc, Description = _description, CategoryId = _categoryId};
            _context.Animals!.Add(newAnimal);
            if (newAnimal != null)
                _context.SaveChanges();
        }
        public List<Category> Categories()
        {
            return _context.categories!.ToList();
        }
    }

    
}
