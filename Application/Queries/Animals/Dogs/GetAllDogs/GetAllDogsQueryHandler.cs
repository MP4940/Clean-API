using MediatR;
using Infrastructure.Database;
using Domain.Models.Animals.Dogs;

namespace Application.Queries.Animals.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllDogsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDatabase = _mockDatabase.AllDogs;
            return Task.FromResult(allDogsFromMockDatabase);
        }
    }
}