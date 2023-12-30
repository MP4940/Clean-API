using Application.Commands.Users.Update;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Delete
{
    public class DeleteUserByIDCommandHandler : IRequestHandler<DeleteUserByIDCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserByIDCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(DeleteUserByIDCommand request, CancellationToken cancellationToken)
        {
            User userToDelete = _userRepository.GetUserByID(request.ID).Result;

            var deletedUser = await _userRepository.DeleteUser(userToDelete);

            return deletedUser;
        }
    }
}