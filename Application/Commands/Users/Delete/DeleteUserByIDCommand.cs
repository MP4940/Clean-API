using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.Delete
{
    public class DeleteUserByIDCommand : IRequest<User>
    {
        public DeleteUserByIDCommand(Guid userID)
        {
            ID = userID;
        }
        public Guid ID { get; set; }
    }
}