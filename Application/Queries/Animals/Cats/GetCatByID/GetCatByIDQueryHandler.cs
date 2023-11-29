using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using MediatR;


namespace Application.Queries.Animals.Cats.GetCatByID
{
    public class GetCatByIDQueryHandler : IRequestHandler<GetCatByIDQuery, Cat>
    {
        private readonly MockDatabase _mockDatabase;
        public GetCatByIDQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Cat> Handle(GetCatByIDQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _mockDatabase.AllCats.Where(cat => cat.AnimalID == request.ID).FirstOrDefault()!;
            return Task.FromResult(wantedCat);
        }
    }
}