using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Cats.AddCat
{
    //public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    //{
    //    private readonly MockDatabase _mockDatabase;

    //    public AddCatCommandHandler(MockDatabase mockDatabase)
    //    {
    //        _mockDatabase = mockDatabase;
    //    }

    //    public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
    //    {
    //        Cat catToCreate = new()
    //        {
    //            AnimalID = Guid.NewGuid(),
    //            Name = request.NewCat.Name,
    //            LikesToPlay = request.NewCat.LikesToPlay
    //        };

    //        _mockDatabase.AllCats.Add(catToCreate);

    //        return Task.FromResult(catToCreate);
    //    }
    //}
}