using Application.Dtos.AnimalUserDto;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Queries.AnimalUsers.GetAllAnimalUsers
{
    public class GetAllAnimalUsersQueryHandler : IRequestHandler<GetAllAnimalUsersQuery, List<GetAllAnimalUsersDto>>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public GetAllAnimalUsersQueryHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<List<GetAllAnimalUsersDto>> Handle(GetAllAnimalUsersQuery request, CancellationToken cancellationToken)
        {
            List<GetAllAnimalUsersDto> allAnimalUsers = await _animalUserRepository.GetAllAnimalUsers();
            return allAnimalUsers;
        }
    }
}