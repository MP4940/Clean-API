using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Animals.Cats.GetAllCats
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {
    }
}
