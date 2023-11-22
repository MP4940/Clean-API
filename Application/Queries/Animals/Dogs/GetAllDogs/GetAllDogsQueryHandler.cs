using MediatR;
using Infrastructure.Database;
using Domain.Models.Animals.Dogs;

namespace Application.Queries.Animals.Dogs.GetAllDogs
{
    internal class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllDogsQueryHandler(MockDatabase mockDataBase)
        {
            _mockDatabase = mockDataBase;
        }

        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDb = _mockDatabase.allDogs;
            return Task.FromResult(allDogsFromMockDb);
        }
    }
}