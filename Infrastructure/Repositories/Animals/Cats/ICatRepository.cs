using Domain.Models.Animals.Cats;

namespace Infrastructure.Repositories.Animals.Cats
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCats();
        Task<Cat> GetCatByID(Guid id);
        Task<Cat> AddCat(Cat catToAdd);
        Task<Cat> UpdateCat(Cat catToUpdate);
        Task<Cat> DeleteCat(Cat catToDelete);
    }
}