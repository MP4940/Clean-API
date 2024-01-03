using Domain.Models.AnimalUsers;
using Infrastructure.Database;

namespace Infrastructure.Repositories.AnimalUsers
{
    public class AnimalUserRepository : IAnimalUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public AnimalUserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
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