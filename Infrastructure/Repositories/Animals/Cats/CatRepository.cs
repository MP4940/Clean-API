using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Serilog;

namespace Infrastructure.Repositories.Animals.Cats
{
    public class CatRepository : ICatRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger _logger;


        public CatRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
            _logger = Log.ForContext<CatRepository>();
        }

        public async Task<List<Cat>> GetAllCats()
        {
            try
            {
                _logger.Information("Getting all cats...");
                List<Cat> allCatsFromDatabase = _realDatabase.Cats.ToList();
                _logger.Information($"Found {allCatsFromDatabase.Count} cats.");
                return await Task.FromResult(allCatsFromDatabase);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while getting all cats.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> GetCatByID(Guid id)
        {
            try
            {
                _logger.Information($"Getting cat by ID {id}...");
                var wantedCat = _realDatabase.Cats.Where(cat => cat.AnimalID == id).FirstOrDefault()!;
                _logger.Information($"cat with ID {wantedCat.AnimalID} found.");
                return await Task.FromResult(wantedCat);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while getting cat by ID {id}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> AddCat(Cat catToAdd)
        {
            try
            {
                _logger.Information($"Adding new cat...");
                _realDatabase.Cats.Add(catToAdd);
                _realDatabase.SaveChanges();
                _logger.Information($"cat added successfully.");
                return await Task.FromResult(catToAdd);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"Error adding cat.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> UpdateCat(Cat catToUpdate)
        {
            try
            {
                _logger.Information($"Updating cat with ID {catToUpdate.AnimalID}...");
                _realDatabase.Cats.Update(catToUpdate);
                _realDatabase.SaveChanges();
                _logger.Information($"Cat with ID {catToUpdate.AnimalID} updated successfully.");
                return await Task.FromResult(catToUpdate);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while updating cat with ID {catToUpdate.AnimalID}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> DeleteCat(Cat catToDelete)
        {
            try
            {
                _logger.Information($"Deleting cat with ID {catToDelete.AnimalID}...");
                _realDatabase.Cats.Remove(catToDelete);
                _realDatabase.SaveChanges();
                _logger.Information($"Cat with ID {catToDelete.AnimalID} deleted successfully.");
                return await Task.FromResult(catToDelete);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while deleting cat with ID {catToDelete.AnimalID}.");
                throw new ArgumentException(e.Message);
            }
        }
    }
}