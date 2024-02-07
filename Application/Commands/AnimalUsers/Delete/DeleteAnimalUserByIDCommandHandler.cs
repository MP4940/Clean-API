using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers.Delete
{
    public class DeleteAnimalUserByIDCommandHandler : IRequestHandler<DeleteAnimalUserByIDCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        public DeleteAnimalUserByIDCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }
        public async Task<AnimalUser> Handle(DeleteAnimalUserByIDCommand request, CancellationToken cancellationToken)
        {
            AnimalUser animalUserToDelete = _animalUserRepository.GetAnimalUserByID(request.ID).Result;

            var deletedAnimalUser = await _animalUserRepository.DeleteAnimalUser(animalUserToDelete);

            return deletedAnimalUser;
        }
    }
}