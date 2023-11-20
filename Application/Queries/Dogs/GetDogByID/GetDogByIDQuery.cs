using MediatR;
using Domain.Models;

namespace Application.Queries.Dogs.GetDogByID
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