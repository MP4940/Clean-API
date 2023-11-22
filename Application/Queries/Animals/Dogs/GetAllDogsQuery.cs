using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Queries.Animals.Dogs
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {
    }
}
