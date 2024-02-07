using FluentValidation;
using Infrastructure.Repositories.Animals.Birds;

namespace Application.Commands.Animals.Birds.AddBird
{
    public class AddBirdCommandValidator : AbstractValidator<AddBirdCommand>
    {
        private readonly IBirdRepository _birdRepository;
        public AddBirdCommandValidator(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;

            RuleFor(command => command.NewBird.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}