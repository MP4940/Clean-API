using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIDCommandHandler : IRequestHandler<UpdateDogByIDCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly UpdateDogByIDCommandValidator _validator;
        public UpdateDogByIDCommandHandler(IDogRepository DogRepository, UpdateDogByIDCommandValidator validator)
        {
            _dogRepository = DogRepository;
            _validator = validator;
        }
        public async Task<Dog> Handle(UpdateDogByIDCommand request, CancellationToken cancellationToken)
        {
            var updateDogByIDCommandValidation = _validator.Validate(request);

            if (!updateDogByIDCommandValidation.IsValid)
            {
                var allErrors = updateDogByIDCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Update error: " + string.Join("; ", allErrors));
            }

            Dog dogToUpdate = _dogRepository.GetDogByID(request.ID).Result;

            dogToUpdate.Name = request.UpdatedDog.Name;
            dogToUpdate.Weight = request.UpdatedDog.Weight;
            dogToUpdate.Breed = request.UpdatedDog.Breed;

            var updatedDog = await _dogRepository.UpdateDog(dogToUpdate);

            return updatedDog;
        }
    }
}