using Application.Commands.Users.Register;
using Application.Dtos.UserDtos;
using Application.Queries.Users.GetAllUsers;
using Application.Queries.Users.GetToken;
using Application.Validators.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly UserValidator _userValidator;

        public UsersController(IMediator mediator, UserValidator userValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserCredentialsDto userToRegister)
        {
            var inputValidation = _userValidator.Validate(userToRegister);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new RegisterUserCommand(userToRegister)));
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Login")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var user = await _mediator.Send(new GetTokenQuery(username, password));

            if (user == null)
            {
                return NotFound("Wrong user");
            }

            var token = user.Token;
            return Ok(token);
        }

        [HttpGet("getAllUsers")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}