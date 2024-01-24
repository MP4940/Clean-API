using Domain.Models.Animals.Birds;

namespace Infrastructure.Repositories.Animals.Birds
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirds();
        Task<Bird> GetBirdByID(Guid id);
        Task<Bird> AddBird(Bird birdToAdd);
        Task<Bird> UpdateBird(Bird birdToUpdate);
        Task<Bird> DeleteBird(Bird birdToDelete);
    }
}