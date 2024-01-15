using FluentValidation;
using Infrastructure.Repositories.AnimalUsers;

namespace Application.Commands.AnimalUsers.Create
{
    public class CreateAnimalUserCommandValidator : AbstractValidator<CreateAnimalUserCommand>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        public CreateAnimalUserCommandValidator(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;

            RuleFor(command => command.AnimalUserDto.AnimalID)
            .NotEmpty().WithMessage("DogID is required.");
            RuleFor(command => command.AnimalUserDto.UserID)
            .NotEmpty().WithMessage("UserID is required.");
        }
    }
}
