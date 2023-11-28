using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Queries.Animals.Birds.GetBirdByID
{
    public class GetBirdByIDQuery : IRequest<Bird>
    {
        public GetBirdByIDQuery(Guid birdID)
        {
            ID = birdID;
        }
        public Guid ID { get; set; }
    }
}