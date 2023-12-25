﻿using Domain.Models.Users;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> RegisterUser(User userToRegister);
        Task<User> UpdateUser(User userToUpdate);
        //Task<User> DeleteUser(User userToDelete);
    }
}