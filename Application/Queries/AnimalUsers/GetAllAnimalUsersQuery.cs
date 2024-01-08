using Application.Dtos.AnimalUserDto;
using MediatR;

namespace Application.Queries.AnimalUsers
{
    public class GetAllAnimalUsersQuery : IRequest<List<GetAllAnimalUsersDto>> { }
}