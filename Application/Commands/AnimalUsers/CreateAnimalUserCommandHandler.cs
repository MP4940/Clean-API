using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers
{
    public class CreateAnimalUserCommandHandler : IRequestHandler<CreateAnimalUserCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public CreateAnimalUserCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<AnimalUser> Handle(CreateAnimalUserCommand request, CancellationToken cancellationToken)
        {
            var animalUserToCreate = new AnimalUser
            {
                AnimalID = request.AnimalUserDto.AnimalID,
                UserID = request.AnimalUserDto.UserID
            };

            var createdAnimalUser = await _animalUserRepository.CreateAnimalUser(animalUserToCreate);

            return createdAnimalUser;
        }
    }
}