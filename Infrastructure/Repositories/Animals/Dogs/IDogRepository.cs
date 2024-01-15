using Domain.Models.Animals.Dogs;

namespace Infrastructure.Repositories.Animals.Dogs
{
    public interface IDogRepository
    {
        Task<Dog> GetDogByID(Guid id);
    }
}