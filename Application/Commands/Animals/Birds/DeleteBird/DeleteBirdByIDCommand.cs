using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.DeleteBird
{
    public class DeleteBirdByIDCommand : IRequest<Bird>
    {
        public DeleteBirdByIDCommand(Guid birdID)
        {
            ID = birdID;
        }
        public Guid ID { get; set; }
    }
}