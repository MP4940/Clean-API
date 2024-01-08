﻿using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;

namespace Infrastructure.Repositories.AnimalUsers
{
    public interface IAnimalUserRepository
    {
        Task<AnimalUser> CreateAnimalUser(AnimalUser animalUser);
        Task<List<GetAllAnimalUsersDto>> GetAllAnimalUsers();
    }
}