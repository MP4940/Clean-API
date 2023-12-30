using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Queries.Users.GetUserByID
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIDQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = await _userRepository.GetUserByID(request.ID);
            return wantedUser;
        }
    }
}