using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Queries.AnimalUsers
{
    public class GetAllAnimalUsersQueryHandler : IRequestHandler<GetAllAnimalUsersQuery, List<AnimalUser>>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public GetAllAnimalUsersQueryHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<List<AnimalUser>> Handle(GetAllAnimalUsersQuery request, CancellationToken cancellationToken)
        {
            List<AnimalUser> allAnimalUsers = await _animalUserRepository.GetAllAnimalUsers();
            return allAnimalUsers;
        }
    }
}