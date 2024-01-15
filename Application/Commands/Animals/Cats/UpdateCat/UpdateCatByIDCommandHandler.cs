using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Cats.UpdateCat
{
    //public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIDCommand, Cat>
    //{
    //    private readonly MockDatabase _mockDatabase;

    //    public UpdateCatByIdCommandHandler(MockDatabase mockDatabase)
    //    {
    //        _mockDatabase = mockDatabase;
    //    }
    //    public Task<Cat> Handle(UpdateCatByIDCommand request, CancellationToken cancellationToken)
    //    {
    //        Cat catToUpdate = _mockDatabase.AllCats.FirstOrDefault(cat => cat.AnimalID == request.ID)!;

    //        catToUpdate.Name = request.UpdatedCat.Name;
    //        catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;

    //        return Task.FromResult(catToUpdate);
    //    }
    //}
}