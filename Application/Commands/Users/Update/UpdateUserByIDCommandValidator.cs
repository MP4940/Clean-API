﻿using Domain.Models.Users;
using FluentValidation;
using Infrastructure.Repositories.Users;

namespace Application.Commands.Users.Update
{
    public class UpdateUserByIDCommandValidator : AbstractValidator<UpdateUserByIDCommand>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserByIDCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(command => command.UserToUpdate.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Must(BeUniqueUsername).WithMessage("Username is already taken.");
        }

        private bool BeUniqueUsername(string username)
        {
            // Check if the username is unique in the database
            List<User> allUsersFromDb = _userRepository.GetAllUsers().Result;
            return !allUsersFromDb.Any(user => user.Username == username);
        }
    }
}