using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.DeleteDog
{
    public class DeleteDogByIDCommand : IRequest<Dog>
    {
        public DeleteDogByIDCommand(Guid dogID)
        {
            ID = dogID;
        }
        public Guid ID { get; set; }
    }
}