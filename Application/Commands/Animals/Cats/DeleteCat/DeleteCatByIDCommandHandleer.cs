using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.DeleteCat
{
    public class DeleteCatByIDCommandHandler : IRequestHandler<DeleteCatByIDCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        public DeleteCatByIDCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(DeleteCatByIDCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _catRepository.GetCatByID(request.ID).Result;

            var deletedCat = await _catRepository.DeleteCat(catToDelete);

            return deletedCat;
        }
    }
}