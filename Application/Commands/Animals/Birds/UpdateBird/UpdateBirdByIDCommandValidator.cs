using FluentValidation;
using Infrastructure.Repositories.Animals.Birds;

namespace Application.Commands.Animals.Birds.UpdateBird
{
    public class UpdateBirdByIDCommandValidator : AbstractValidator<UpdateBirdByIDCommand>
    {
        private readonly IBirdRepository _birdRepository;
        public UpdateBirdByIDCommandValidator(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;

            RuleFor(command => command.UpdatedBird.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}