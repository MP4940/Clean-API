using MediatR;
using Domain.Models.Animals.Dogs;

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