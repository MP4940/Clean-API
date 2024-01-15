using FluentValidation;
using Infrastructure.Repositories.AnimalUsers;

namespace Application.Commands.AnimalUsers.Update
{
    public class UpdateAnimalUserByIDCommandValidator : AbstractValidator<UpdateAnimalUserByIDCommand>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        public UpdateAnimalUserByIDCommandValidator(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;

            RuleFor(command => command.AnimalUserToUpdate.AnimalID)
            .NotEmpty().WithMessage("DogID is required.");
            RuleFor(command => command.AnimalUserToUpdate.UserID)
            .NotEmpty().WithMessage("UserID is required.");
        }
    }
}