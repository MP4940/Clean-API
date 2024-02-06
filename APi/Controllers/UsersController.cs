using Application.Commands.Users.Register;
using Application.Commands.Users.Update;
using Application.Commands.Users.Delete;
using Application.Dtos.UserDtos;
using Application.Queries.Users.GetAllUsers;
using Application.Queries.Users.GetToken;
using Application.Queries.Users.GetUserByID;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        

        public UsersController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserCredentialsDto userToRegister)
        {
            try
            {
                return Ok(await _mediatR.Send(new RegisterUserCommand(userToRegister)));
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
            var user = await _mediatR.Send(new GetTokenQuery(username, password));

            if (user == null)
            {
                return NotFound("Wrong user");
            }

            var token = user.Token;
            return Ok(token);
        }

        [HttpGet("getAllUsers")]
        //[Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _mediatR.Send(new GetAllUsersQuery());
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("getUserByID/{userID}")]
        //[Authorize]
        public async Task<IActionResult> GetUserByID(Guid userID)
        {
            try
            {
                return Ok(await _mediatR.Send(new GetUserByIDQuery(userID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("updateUser/{updatedUserID}")]
        //[Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserCredentialsDto updatedUser, Guid updatedUserID)
        {
            try
            {
                return Ok(await _mediatR.Send(new UpdateUserByIDCommand(updatedUser, updatedUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("deleteUser/{deletedUserID}")]
        //[Authorize]
        public async Task<IActionResult> DeleteUser(Guid deletedUserID)
        {
            try
            {
                return Ok(await _mediatR.Send(new DeleteUserByIDCommand(deletedUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}