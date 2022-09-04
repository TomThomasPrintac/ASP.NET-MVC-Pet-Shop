using AnimalsWebApplication.Models;

namespace AnimalsWebApplication.Repository
{
    public interface IRepository
    {
        List<Animal> MostComments();
        List<Animal> AllAnimals();
        List<Animal> GetAnimalsByCategory(string category);
        Animal ShowDeteils(int id);
        void SaveComment();
        void AddComment(int id, string commentText);
        void Delete(int id);
        Animal FindAnimal(int id);
        void EditAnimal(Animal animal);
        void AddNewAnimal(string _name, int _age, string _pictureSrc, string _description, int _categoryId);
        List<Category> Categories();
    }
}
