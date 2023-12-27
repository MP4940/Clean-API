﻿using Azure.Core;
using Domain.Models.Users;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<User> RegisterUser(User userToRegister)
        {
            try
            {
                _realDatabase.Users.Add(userToRegister);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToRegister);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                List<User> allUsersFromDatabase = _realDatabase.Users.ToList();
                return await Task.FromResult(allUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<User> GetUserByID(Guid id)
        {
            try
            {
                var wantedUser = _realDatabase.Users.Where(user => user.ID == id).FirstOrDefault()!;
                return await Task.FromResult(wantedUser);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }
        public async Task<User> UpdateUser(User userToUpdate)
        {
            try
            {
                _realDatabase.Users.Update(userToUpdate);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToUpdate);
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