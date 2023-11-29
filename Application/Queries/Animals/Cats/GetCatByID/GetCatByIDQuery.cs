using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetCatByID
{
    public class GetCatByIDQuery : IRequest<Cat>
    {
        public GetCatByIDQuery(Guid catID)
        {
            ID = catID;
        }
        public Guid ID { get; set; }
    }
}