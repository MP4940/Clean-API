using Domain.Models.Animals.Cats;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Animals.Cats
{
    public class CatRepository : ICatRepository
    {
        private readonly RealDatabase _realDatabase;

        public CatRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<List<Cat>> GetAllCats()
        {
            try
            {
                List<Cat> allCatsFromDatabase = _realDatabase.Cats.ToList();
                return await Task.FromResult(allCatsFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> GetCatByID(Guid id)
        {
            try
            {
                var wantedCat = _realDatabase.Cats.Where(Cat => Cat.CatID == id).FirstOrDefault()!;
                return await Task.FromResult(wantedCat);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering Cat");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> AddCat(Cat CatToAdd)
        {
            try
            {
                _realDatabase.Cats.Add(CatToAdd);
                _realDatabase.SaveChanges();
                return await Task.FromResult(CatToAdd);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> UpdateCat(Cat CatToUpdate)
        {
            try
            {
                _realDatabase.Cats.Update(CatToUpdate);
                _realDatabase.SaveChanges();
                return await Task.FromResult(CatToUpdate);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Cat> DeleteCat(Cat CatToDelete)
        {
            try
            {
                _realDatabase.Cats.Remove(CatToDelete);
                _realDatabase.SaveChanges();
                return await Task.FromResult(CatToDelete);
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