using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories.AnimalUsers
{
    public class AnimalUserRepository : IAnimalUserRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger _logger;

        public AnimalUserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
            _logger = Log.ForContext<CatRepository>();
        }

        public async Task<List<GetAllAnimalUsersDto>> GetAllAnimalUsers()
        {
            try
            {
                _logger.Information("Getting all animal users...");
                var animalUsers = await _realDatabase.AnimalUsers
                    .Select(au => new GetAllAnimalUsersDto
                    {
                        Username = au.User.Username,
                        AnimalName = au.Animal.Name,
                    })
                    .ToListAsync();
                _logger.Information($"Found {animalUsers.Count} animal users.");
                return animalUsers;
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while getting all animal users.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> GetAnimalUserByID(Guid id)
        {
            try
            {
                _logger.Information($"Getting animal user by ID: {id}...");
                var wantedAnimalUser = _realDatabase.AnimalUsers.Where(animalUser => animalUser.Key == id).FirstOrDefault()!;
                _logger.Information($"Found animal user with ID: {id}.");
                return await Task.FromResult(wantedAnimalUser);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while getting animal user by ID: {id}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> CreateAnimalUser(AnimalUser animalUser)
        {
            try
            {
                _logger.Information("Creating user animal...");
                _realDatabase.AnimalUsers.Add(animalUser);
                _realDatabase.SaveChanges();
                _logger.Information("User animal created successfully.");
                return await Task.FromResult(animalUser);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while creating user animal.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> UpdateAnimalUser(AnimalUser animalUserToUpdate)
        {
            try
            {
                _logger.Information($"Updating animal user with ID: {animalUserToUpdate.Key}...");
                _realDatabase.AnimalUsers.Update(animalUserToUpdate);
                _realDatabase.SaveChanges();
                _logger.Information($"Animal user with ID: {animalUserToUpdate.Key} updated successfully.");
                return await Task.FromResult(animalUserToUpdate);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while updating animal user with ID: {animalUserToUpdate.Key}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> DeleteAnimalUser(AnimalUser animalUserToDelete)
        {
            try
            {
                _logger.Information($"Deleting animal user with key: {animalUserToDelete.Key}...");
                _realDatabase.AnimalUsers.Remove(animalUserToDelete);
                _realDatabase.SaveChanges();
                _logger.Information($"Animal user with key: {animalUserToDelete.Key} deleted successfully.");
                return await Task.FromResult(animalUserToDelete);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while deleting animal user with key: {animalUserToDelete.Key}.");
                throw new ArgumentException(e.Message);
            }
        }
    }
}