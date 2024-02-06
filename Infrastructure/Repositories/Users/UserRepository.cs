using Domain.Models.Users;
using Infrastructure.Database;
using Serilog;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger _logger;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
            _logger = Log.ForContext<UserRepository>();
        }

        public async Task<User> RegisterUser(User userToRegister)
        {
            try
            {
                _logger.Information("Adding new user...");
                _realDatabase.Users.Add(userToRegister);
                _realDatabase.SaveChanges();
                _logger.Information("User added successfully.");
                return await Task.FromResult(userToRegister);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while adding new user.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                _logger.Information("Getting all users...");
                List<User> allUsersFromDatabase = _realDatabase.Users.ToList();
                _logger.Information($"Found {allUsersFromDatabase.Count} users.");
                return await Task.FromResult(allUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, "An error occurred while getting all users.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<User> GetUserByID(Guid id)
        {
            try
            {
                _logger.Information($"Getting user by ID: {id}...");
                var wantedUser = _realDatabase.Users.Where(user => user.ID == id).FirstOrDefault()!;
                _logger.Information($"Found user with ID: {id}.");
                return await Task.FromResult(wantedUser);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while getting user by ID: {id}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<User> UpdateUser(User userToUpdate)
        {
            try
            {
                _logger.Information($"Updating user with ID: {userToUpdate.ID}...");
                _realDatabase.Users.Update(userToUpdate);
                _realDatabase.SaveChanges();
                _logger.Information($"User with ID: {userToUpdate.ID} updated successfully.");
                return await Task.FromResult(userToUpdate);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while updating user with ID: {userToUpdate.ID}.");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<User> DeleteUser(User userToDelete)
        {
            try
            {
                _logger.Information($"Deleting user with ID: {userToDelete.ID}...");
                _realDatabase.Users.Remove(userToDelete);
                _realDatabase.SaveChanges();
                _logger.Information($"User with ID: {userToDelete.ID} deleted successfully.");
                return await Task.FromResult(userToDelete);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e, $"An error occurred while deleting user with ID: {userToDelete.ID}.");
                throw new ArgumentException(e.Message);
            }
        }
    }
}