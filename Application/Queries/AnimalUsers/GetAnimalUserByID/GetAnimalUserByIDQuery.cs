using Domain.Models.AnimalUsers;
using MediatR;

namespace Application.Queries.Users.GetAnimalUserByID
{
    public class GetAnimalUserByIDQuery : IRequest<AnimalUser>
    {
        public GetAnimalUserByIDQuery(Guid animalUserID)
        {
            ID = animalUserID;
        }
        public Guid ID { get; set; }
    }
}