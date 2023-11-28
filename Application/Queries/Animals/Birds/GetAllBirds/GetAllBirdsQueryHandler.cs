using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Animals.Birds.GetAllBirds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllBirdsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromMockDatabase = _mockDatabase.allBirds;
            return Task.FromResult(allBirdsFromMockDatabase);
        }
    }
}