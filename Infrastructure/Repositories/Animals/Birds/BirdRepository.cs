using Domain.Models.Animals.Birds;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Animals.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly RealDatabase _realDatabase;

        public BirdRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<List<Bird>> GetAllBirds()
        {
            try
            {
                List<Bird> allBirdsFromDatabase = _realDatabase.Birds.ToList();
                return await Task.FromResult(allBirdsFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> GetBirdByID(Guid id)
        {
            try
            {
                var wantedBird = _realDatabase.Birds.Where(bird => bird.AnimalID == id).FirstOrDefault()!;
                return await Task.FromResult(wantedBird);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering bird");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> AddBird(Bird birdToAdd)
        {
            try
            {
                _realDatabase.Birds.Add(birdToAdd);
                _realDatabase.SaveChanges();
                return await Task.FromResult(birdToAdd);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> UpdateBird(Bird birdToUpdate)
        {
            try
            {
                _realDatabase.Birds.Update(birdToUpdate);
                _realDatabase.SaveChanges();
                return await Task.FromResult(birdToUpdate);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> DeleteBird(Bird birdToDelete)
        {
            try
            {
                _realDatabase.Birds.Remove(birdToDelete);
                _realDatabase.SaveChanges();
                return await Task.FromResult(birdToDelete);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }
    }
}