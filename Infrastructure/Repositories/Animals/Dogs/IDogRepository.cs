using Domain.Models.Animals.Dogs;

namespace Infrastructure.Repositories.Animals.Dogs
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogs();
        Task<Dog> GetDogByID(Guid id);
        Task<Dog> AddDog(Dog dogToAdd);
        Task<Dog> UpdateDog(Dog dogToUpdate);
        Task<Dog> DeleteDog(Dog dogToDelete);
    }
}