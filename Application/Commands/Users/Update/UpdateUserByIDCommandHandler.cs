using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Update
{
    public class UpdateUserByIDCommandHandler : IRequestHandler<UpdateUserByIDCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly UpdateUserByIDCommandValidator _validator;
        public UpdateUserByIDCommandHandler(IUserRepository userRepository, UpdateUserByIDCommandValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<User> Handle(UpdateUserByIDCommand request, CancellationToken cancellationToken)
        {
            var updateUserByIDCommandValidation = _validator.Validate(request);

            if (!updateUserByIDCommandValidation.IsValid)
            {
                var allErrors = updateUserByIDCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Update error: " + string.Join("; ", allErrors));
            }

            User userToUpdate = _userRepository.GetUserByID(request.ID).Result;

            userToUpdate.Username = request.UserToUpdate.Username;
            userToUpdate.Password = request.UserToUpdate.Password;
            userToUpdate.Role = request.UserToUpdate.Role;

            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            return updatedUser;
        }
    }
}