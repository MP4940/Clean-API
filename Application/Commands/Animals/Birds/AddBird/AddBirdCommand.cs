using Application.Dtos.AnimalsDtos.BirdDto;
using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.AddBird
{
    public class AddBirdCommand : IRequest<Bird>
    {
        public AddBirdCommand(BirdDto newBird)
        {
            NewBird = newBird;
        }
        public BirdDto NewBird { get; }
    }
}