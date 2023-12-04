using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Queries.Animals.Dogs.GetDogByID
{
    public class GetDogByIDQuery : IRequest<Dog>
    {
        public GetDogByIDQuery(Guid dogID)
        {
            ID = dogID;
        }
        public Guid ID { get; set; }
    }
}