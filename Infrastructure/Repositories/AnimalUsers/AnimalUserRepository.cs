using Domain.Models.Animals;
using Domain.Models.AnimalUsers;
using Domain.Models.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AnimalUsers
{
    public class AnimalUserRepository : IAnimalUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public AnimalUserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<List<AnimalUser>> GetAllAnimalUsers()
        {
            try
            {
                //_realDatabase.Users.Include(x => x.ID).Select(entry => entry.Animals);
                List <AnimalUser> allAnimalUsersFromDatabase = _realDatabase.AnimalUsers.ToList();
                return await Task.FromResult(allAnimalUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> CreateAnimalUser(AnimalUser animalUser)
        {
            try
            {
                _realDatabase.AnimalUsers.Add(animalUser);
                _realDatabase.SaveChanges();
                return await Task.FromResult(animalUser);
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