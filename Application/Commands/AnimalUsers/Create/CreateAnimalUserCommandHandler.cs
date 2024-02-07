using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers.Create
{
    public class CreateAnimalUserCommandHandler : IRequestHandler<CreateAnimalUserCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        private readonly CreateAnimalUserCommandValidator _validator;

        public CreateAnimalUserCommandHandler(IAnimalUserRepository animalUserRepository, CreateAnimalUserCommandValidator validator)
        {
            _animalUserRepository = animalUserRepository;
            _validator = validator;
        }

        public async Task<AnimalUser> Handle(CreateAnimalUserCommand request, CancellationToken cancellationToken)
        {
            var createCommandValidation = _validator.Validate(request);

            if (!createCommandValidation.IsValid)
            {
                var allErrors = createCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            var animalUserToCreate = new AnimalUser
            {
                Key = Guid.NewGuid(),
                AnimalID = request.AnimalUserDto.AnimalID,
                UserID = request.AnimalUserDto.UserID
            };

            var createdAnimalUser = await _animalUserRepository.CreateAnimalUser(animalUserToCreate);

            return createdAnimalUser;
        }
    }
}