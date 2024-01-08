using Application.Dtos.AnimalUserDto;
using MediatR;

namespace Application.Queries.AnimalUsers.GetAllAnimalUsers
{
    public class GetAllAnimalUsersQuery : IRequest<List<GetAllAnimalUsersDto>> { }
}