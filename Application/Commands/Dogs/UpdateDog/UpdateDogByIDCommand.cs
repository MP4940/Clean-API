using Application.Dtos;
using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIDCommand : IRequest<Dog>
    {
        public UpdateDogByIDCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            Id = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid Id { get; }
    }
}
