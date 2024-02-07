using Application.Dtos.UserDtos;
using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.Update
{
    public class UpdateUserByIDCommand : IRequest<User>
    {
        public UpdateUserByIDCommand(UserCredentialsDto userToUpdate, Guid id)
        {
            UserToUpdate = userToUpdate;
            ID = id;
        }
        public UserCredentialsDto UserToUpdate { get; }
        public Guid ID { get; }
    }
}