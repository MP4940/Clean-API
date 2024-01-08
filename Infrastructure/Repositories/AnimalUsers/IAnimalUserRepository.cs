using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;

namespace Infrastructure.Repositories.AnimalUsers
{
    public interface IAnimalUserRepository
    {
        Task<AnimalUser> CreateAnimalUser(AnimalUser animalUserToCreate);
        Task<AnimalUser> UpdateAnimalUser(AnimalUser animalUserToUpdate);
        Task<List<GetAllAnimalUsersDto>> GetAllAnimalUsers();
    }
}