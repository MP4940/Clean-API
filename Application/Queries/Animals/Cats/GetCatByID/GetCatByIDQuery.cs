using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetCatByID
{
    public class GetCatByIDQuery : IRequest<Cat>
    {
        public GetCatByIDQuery(Guid CatID)
        {
            ID = CatID;
        }
        public Guid ID { get; set; }
    }
}