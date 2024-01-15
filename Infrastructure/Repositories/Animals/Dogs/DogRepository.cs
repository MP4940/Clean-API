using Domain.Models.Animals.Dogs;
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
    }
}