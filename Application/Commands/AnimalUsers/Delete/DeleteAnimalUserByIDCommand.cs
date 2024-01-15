using Domain.Models.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers.Delete
{
    public class DeleteAnimalUserByIDCommand : IRequest<AnimalUser>
    {
        public DeleteAnimalUserByIDCommand(Guid animalUserID)
        {
            ID = animalUserID;
        }
        public Guid ID { get; set; }
    }
}