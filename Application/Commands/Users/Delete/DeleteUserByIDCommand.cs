using Application.Validators;
using Domain.Models.Users;
using FluentValidation;
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
        public void Validate()
        {
            var validator = new GuidValidator();
            var result = validator.Validate(ID);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}