using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Serilog;

namespace Infrastructure.Repositories.Animals.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger _logger;


        public BirdRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
            _logger = Log.ForContext<BirdRepository>();
        }

        public async Task<List<Bird>> GetAllBirds()
        {
            try
            {
                _logger.Information("Getting all birds...");
                List<Bird> allBirdsFromDatabase = _realDatabase.Birds.ToList();
                _logger.Information($"Found {allBirdsFromDatabase.Count} birds.");
                return await Task.FromResult(allBirdsFromDatabase);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while getting all birds.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> GetBirdByID(Guid id)
        {
            try
            {
                _logger.Information($"Getting bird by ID {id}...");
                var wantedBird = _realDatabase.Birds.Where(bird => bird.AnimalID == id).FirstOrDefault()!;
                _logger.Information($"Bird with ID {wantedBird.AnimalID} found.");
                return await Task.FromResult(wantedBird);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while getting bird by ID {id}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> AddBird(Bird birdToAdd)
        {
            try
            {
                _logger.Information($"Adding new bird...");
                _realDatabase.Birds.Add(birdToAdd);
                _realDatabase.SaveChanges();
                _logger.Information($"Bird added successfully.");
                return await Task.FromResult(birdToAdd);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"Error adding bird.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> UpdateBird(Bird birdToUpdate)
        {
            try
            {
                _logger.Information($"Updating bird with ID {birdToUpdate.AnimalID}...");
                _realDatabase.Birds.Update(birdToUpdate);
                _realDatabase.SaveChanges();
                _logger.Information($"Bird with ID {birdToUpdate.AnimalID} updated successfully.");
                return await Task.FromResult(birdToUpdate);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while updating bird with ID {birdToUpdate.AnimalID}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Bird> DeleteBird(Bird birdToDelete)
        {
            try
            {
                _logger.Information($"Deleting bird with ID {birdToDelete.AnimalID}...");
                _realDatabase.Birds.Remove(birdToDelete);
                _realDatabase.SaveChanges();
                _logger.Information($"Bird with ID {birdToDelete.AnimalID} deleted successfully.");
                return await Task.FromResult(birdToDelete);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while deleting bird with ID {birdToDelete.AnimalID}.");
                throw new ArgumentException(e.Message);
            }
        }
    }
}