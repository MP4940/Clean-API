using Application.Dtos.AnimalsDtos.BirdDto;
using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.UpdateBird
{
    public class UpdateBirdByIDCommand : IRequest<Bird>
    {
        public UpdateBirdByIDCommand(BirdDto updatedBird, Guid id)
        {
            UpdatedBird = updatedBird;
            ID = id;
        }
        public BirdDto UpdatedBird { get; }
        public Guid ID { get; }
    }
}