using Application.Commands.AnimalUsers.Create;
using Application.Commands.AnimalUsers.Delete;
using Application.Commands.AnimalUsers.Update;
using Application.Dtos.AnimalUserDto;
using Application.Queries.AnimalUsers.GetAllAnimalUsers;
using Application.Queries.Users.GetAnimalUserByID;
using Application.Validators;
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

        [HttpGet("getAllAnimalUsers")]
        //[Authorize]
        public async Task<IActionResult> GetAllAnimalUsers()
        {
            try
            {
                var animalUsers = await _mediatR.Send(new GetAllAnimalUsersQuery());
                return Ok(animalUsers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("getAnimalUserByID/{animalUserID}")]
        //[Authorize]
        public async Task<IActionResult> GetAnimalUserByID(Guid animalUserID)
        {
            var guidToValidate = _guidValidator.Validate(animalUserID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new GetAnimalUserByIDQuery(animalUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("updateAnimalUser/{updatedAnimalUserID}")]
        //[Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] AnimalUserDto updatedAnimalUser, Guid updatedAnimalUserID)
        {
            // Validate animalUser
            //var animalUserToValidate = _animalUserValidator.Validate(updatedAnimalUser);

            //if (!animalUserToValidate.IsValid)
            //{
            //    return BadRequest(animalUserToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            //}

            try
            {
                return Ok(await _mediatR.Send(new UpdateAnimalUserByIDCommand(updatedAnimalUser, updatedAnimalUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("deleteAnimalUser/{deletedAnimalUserID}")]
        //[Authorize]
        public async Task<IActionResult> DeleteAnimalUser(Guid deletedAnimalUserID)
        {
            var guidToValidate = _guidValidator.Validate(deletedAnimalUserID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new DeleteAnimalUserByIDCommand(deletedAnimalUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}