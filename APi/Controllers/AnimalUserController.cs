using Application.Commands.AnimalUsers;
using Application.Dtos.AnimalUserDto;
using Application.Validators;
using Application.Validators.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalUserController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        internal readonly GuidValidator _guidValidator;

        public AnimalUserController(IMediator mediator, GuidValidator guidValidator)
        {
            _mediatR = mediator;
            _guidValidator = guidValidator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AnimalUserDto animalUserToCreate)
        {
            try
            {
                return Ok(await _mediatR.Send(new CreateAnimalUserCommand(animalUserToCreate)));
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                return BadRequest(e.Message);
            }
        }
    }
}