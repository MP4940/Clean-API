using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Queries.Animals.Birds.GetBirdsByColor
{
    public class GetBirdsByColorQuery : IRequest<List<Bird>>
    {
        public required string Color { get; set; }
    }
}