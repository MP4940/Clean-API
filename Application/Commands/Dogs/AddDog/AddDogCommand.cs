using Application.Dtos;
using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    public class AddDogCommand : IRequest<Dog>
    {
        public AddDogCommand(DogDto newDog)
        {
            NewDog = newDog;
        }
        public DogDto NewDog { get; }
    }
}
