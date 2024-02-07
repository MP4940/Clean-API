using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers.Update
{
    public class UpdateAnimalUserByIDCommandHandler : IRequestHandler<UpdateAnimalUserByIDCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        private readonly UpdateAnimalUserByIDCommandValidator _validator;
        public UpdateAnimalUserByIDCommandHandler(IAnimalUserRepository animalUserRepository, UpdateAnimalUserByIDCommandValidator validator)
        {
            _animalUserRepository = animalUserRepository;
            _validator = validator;
        }
        public async Task<AnimalUser> Handle(UpdateAnimalUserByIDCommand request, CancellationToken cancellationToken)
        {
            var updateUserByIDCommandValidation = _validator.Validate(request);

            if (!updateUserByIDCommandValidation.IsValid)
            {
                var allErrors = updateUserByIDCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Update error: " + string.Join("; ", allErrors));
            }

            AnimalUser animalUserToUpdate = _animalUserRepository.GetAnimalUserByID(request.ID).Result;

            animalUserToUpdate.AnimalID = request.AnimalUserToUpdate.AnimalID;
            animalUserToUpdate.UserID = request.AnimalUserToUpdate.UserID;

            var updatedAnimalUser = await _animalUserRepository.UpdateAnimalUser(animalUserToUpdate);

            return updatedAnimalUser;
        }
    }
}
