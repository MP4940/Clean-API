using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Queries.Users.GetAnimalUserByID
{
    public class GetAnimalUserByIDQueryHandler : IRequestHandler<GetAnimalUserByIDQuery, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public GetAnimalUserByIDQueryHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<AnimalUser> Handle(GetAnimalUserByIDQuery request, CancellationToken cancellationToken)
        {
            AnimalUser wantedAnimalUser = await _animalUserRepository.GetAnimalUserByID(request.ID);
            return wantedAnimalUser;
        }
    }
}