using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.UpdateCat
{
    public class UpdateCatByIDCommandHandler : IRequestHandler<UpdateCatByIDCommand, Cat>
    {
        private readonly ICatRepository _CatRepository;
        private readonly UpdateCatByIDCommandValidator _validator;
        public UpdateCatByIDCommandHandler(ICatRepository CatRepository, UpdateCatByIDCommandValidator validator)
        {
            _CatRepository = CatRepository;
            _validator = validator;
        }
        public async Task<Cat> Handle(UpdateCatByIDCommand request, CancellationToken cancellationToken)
        {
            var updateCatByIDCommandValidation = _validator.Validate(request);

            if (!updateCatByIDCommandValidation.IsValid)
            {
                var allErrors = updateCatByIDCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Update error: " + string.Join("; ", allErrors));
            }

            Cat catToUpdate = _CatRepository.GetCatByID(request.ID).Result;

            catToUpdate.Name = request.UpdatedCat.Name;
            catToUpdate.Weight = request.UpdatedCat.Weight;
            catToUpdate.Breed = request.UpdatedCat.Breed;

            var updatedCat = await _CatRepository.UpdateCat(catToUpdate);

            return updatedCat;
        }
    }
}