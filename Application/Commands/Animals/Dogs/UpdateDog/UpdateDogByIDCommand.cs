using Application.Dtos.AnimalsDtos.DogDto;
using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIDCommand : IRequest<Dog>
    {
        public UpdateDogByIDCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            ID = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid ID { get; }
    }
}
