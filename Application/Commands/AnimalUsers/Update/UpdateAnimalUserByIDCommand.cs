using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers.Update
{
    public class UpdateAnimalUserByIDCommand : IRequest<AnimalUser>
    {
        public UpdateAnimalUserByIDCommand(AnimalUserDto animalUserToUpdate, Guid id)
        {
            AnimalUserToUpdate = animalUserToUpdate;
            ID = id;
        }
        public AnimalUserDto AnimalUserToUpdate { get; }
        public Guid ID { get; }
    }
}