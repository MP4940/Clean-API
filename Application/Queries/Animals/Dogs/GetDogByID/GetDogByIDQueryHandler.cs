using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using MediatR;


namespace Application.Queries.Animals.Dogs.GetDogByID
{
    public class GetDogByIDQueryHandler : IRequestHandler<GetDogByIDQuery, Dog>
    {
        private readonly MockDatabase _mockDatabase;
        public GetDogByIDQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(GetDogByIDQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = _mockDatabase.allDogs.Where(Dog => Dog.AnimalID == request.ID).FirstOrDefault()!;
            return Task.FromResult(wantedDog);
        }
    }
}