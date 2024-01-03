using Domain.Models.AnimalUsers;
using MediatR;

namespace Application.Queries.AnimalUsers
{
    public class GetAllAnimalUsersQuery : IRequest<List<AnimalUser>> { }
}