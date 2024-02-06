using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Serilog;

namespace Infrastructure.Repositories.Animals.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger _logger;


        public DogRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
            _logger = Log.ForContext<DogRepository>();
        }

        public async Task<List<Dog>> GetAllDogs()
        {
            try
            {
                _logger.Information("Getting all dogs...");
                List<Dog> allDogsFromDatabase = _realDatabase.Dogs.ToList();
                _logger.Information($"Found {allDogsFromDatabase.Count} dogs.");
                return await Task.FromResult(allDogsFromDatabase);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while getting all dogs.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> GetDogByID(Guid id)
        {
            try
            {
                _logger.Information($"Getting dog by ID {id}...");
                var wantedDog = _realDatabase.Dogs.Where(dog => dog.AnimalID == id).FirstOrDefault()!;
                _logger.Information($"Dog with ID {wantedDog.AnimalID} found.");
                return await Task.FromResult(wantedDog);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while getting dog by ID {id}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> AddDog(Dog dogToAdd)
        {
            try
            {
                _logger.Information($"Adding new dog...");
                _realDatabase.Dogs.Add(dogToAdd);
                _realDatabase.SaveChanges();
                _logger.Information($"Dog added successfully.");
                return await Task.FromResult(dogToAdd);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"Error adding dog.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> UpdateDog(Dog dogToUpdate)
        {
            try
            {
                _logger.Information($"Updating dog with ID {dogToUpdate.AnimalID}...");
                _realDatabase.Dogs.Update(dogToUpdate);
                _realDatabase.SaveChanges();
                _logger.Information($"Dog with ID {dogToUpdate.AnimalID} updated successfully.");
                return await Task.FromResult(dogToUpdate);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while updating dog with ID {dogToUpdate.AnimalID}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> DeleteDog(Dog dogToDelete)
        {
            try
            {
                _logger.Information($"Deleting dog with ID {dogToDelete.AnimalID}...");
                _realDatabase.Dogs.Remove(dogToDelete);
                _realDatabase.SaveChanges();
                _logger.Information($"Dog with ID {dogToDelete.AnimalID} deleted successfully.");
                return await Task.FromResult(dogToDelete);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while deleting dog with ID {dogToDelete.AnimalID}.");
                throw new ArgumentException(e.Message);
            }
        }
    }
}