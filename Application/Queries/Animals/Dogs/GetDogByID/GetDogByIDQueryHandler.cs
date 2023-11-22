using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using MediatR;


namespace Application.Queries.Animals.Dogs.GetDogByID
{
    internal class GetDogByIDQueryHandler : IRequestHandler<GetDogByIDQuery, Dog>
    {
        private readonly MockDatabase _mockDatabase;
        public GetDogByIDQueryHandler(MockDatabase mockDataBase)
        {
            _mockDatabase = mockDataBase;
        }
        public Task<Dog> Handle(GetDogByIDQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = _mockDatabase.allDogs.Where(Dog => Dog.AnimalID == request.ID).FirstOrDefault()!;
            return Task.FromResult(wantedDog);

        }
    }
}