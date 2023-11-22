using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Queries.Animals.Dogs.GetAllDogs
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {
    }
}
