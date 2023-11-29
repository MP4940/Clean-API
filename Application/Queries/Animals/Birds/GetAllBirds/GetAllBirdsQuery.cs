using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Queries.Animals.Birds.GetAllBirds
{
    public class GetAllBirdsQuery : IRequest<List<Bird>> { }
}