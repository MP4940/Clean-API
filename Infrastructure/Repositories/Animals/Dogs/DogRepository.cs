using Domain.Models.Animals.Dogs;
using Domain.Models.Users;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Animals.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDatabase _realDatabase;

        public DogRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<List<Dog>> GetAllDogs()
        {
            try
            {
                List<Dog> allDogsFromDatabase = _realDatabase.Dogs.ToList();
                return await Task.FromResult(allDogsFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> GetDogByID(Guid id)
        {
            try
            {
                var wantedDog = _realDatabase.Dogs.Where(Dog => Dog.DogID == id).FirstOrDefault()!;
                return await Task.FromResult(wantedDog);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering Dog");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> AddDog(Dog dogToAdd)
        {
            try
            {
                _realDatabase.Dogs.Add(dogToAdd);
                _realDatabase.SaveChanges();
                return await Task.FromResult(dogToAdd);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> UpdateDog(Dog dogToUpdate)
        {
            try
            {
                _realDatabase.Dogs.Update(dogToUpdate);
                _realDatabase.SaveChanges();
                return await Task.FromResult(dogToUpdate);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Dog> DeleteDog(Dog dogToDelete)
        {
            try
            {
                _realDatabase.Dogs.Remove(dogToDelete);
                _realDatabase.SaveChanges();
                return await Task.FromResult(dogToDelete);
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