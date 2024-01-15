using Application.Dtos.AnimalUserDto;
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

        public async Task<List<GetAllAnimalUsersDto>> GetAllAnimalUsers()
        {
            try
            {
                var animalUsers = await _realDatabase.AnimalUsers
                    .Select(au => new GetAllAnimalUsersDto
                    {
                        Username = au.User.Username,
                        AnimalName = au.Animal.Name,
                        AnimalType = au.Animal.Type
                    })
                    .ToListAsync();
                return animalUsers;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> GetAnimalUserByID(Guid id)
        {
            try
            {
                var wantedAnimalUser = _realDatabase.AnimalUsers.Where(animalUser => animalUser.Key == id).FirstOrDefault()!;
                return await Task.FromResult(wantedAnimalUser);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
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

        public async Task<AnimalUser> UpdateAnimalUser(AnimalUser animalUserToUpdate)
        {
            try
            {
                _realDatabase.AnimalUsers.Update(animalUserToUpdate);
                _realDatabase.SaveChanges();
                return await Task.FromResult(animalUserToUpdate);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<AnimalUser> DeleteAnimalUser(AnimalUser animalUserToDelete)
        {
            try
            {
                _realDatabase.AnimalUsers.Remove(animalUserToDelete);
                _realDatabase.SaveChanges();
                return await Task.FromResult(animalUserToDelete);
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