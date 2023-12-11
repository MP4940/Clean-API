using Application.Commands.Animals.Birds.AddBird;
using Application.Commands.Animals.Birds.DeleteBird;
using Application.Commands.Animals.Birds.UpdateBird;
using Application.Dtos.AnimalsDtos.BirdDto;
using Application.Queries.Animals.Birds.GetAllBirds;
using Application.Queries.Animals.Birds.GetBirdByID;
using Application.Validators;
using Application.Validators.Bird;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        internal readonly GuidValidator _guidValidator;
        internal readonly BirdValidator _birdValidator;

        public BirdsController(IMediator mediatR, GuidValidator guidValidator, BirdValidator birdValidator)
        {
            _mediatR = mediatR;
            _guidValidator = guidValidator;
            _birdValidator = birdValidator;
        }

        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            try
            {
                return Ok(await _mediatR.Send(new GetAllBirdsQuery()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getBirdById/{birdID}")]
        public async Task<IActionResult> GetBirdById(Guid birdID)
        {
            var guidToValidate = _guidValidator.Validate(birdID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new GetBirdByIDQuery(birdID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new Bird 
        [HttpPost]
        [Authorize]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            // Validate Bird
            var birdToValidate = _birdValidator.Validate(newBird);

            // Error handling
            if (!birdToValidate.IsValid)
            {
                return BadRequest(birdToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try catch
            try
            {
                return Ok(await _mediatR.Send(new AddBirdCommand(newBird)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific Bird
        [HttpPut]
        [Authorize]
        [Route("updateBird/{updatedBirdID}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdID)
        {
            // Validate Bird
            var birdToValidate = _birdValidator.Validate(updatedBird);

            // Error handling
            if (!birdToValidate.IsValid)
            {
                return BadRequest(birdToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try catch
            try
            {
                return Ok(await _mediatR.Send(new UpdateBirdByIDCommand(updatedBird, updatedBirdID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific Bird
        [HttpDelete]
        [Authorize]
        [Route("deleteBird/{deletedBirdID}")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdID)
        {
            var guidToValidate = _guidValidator.Validate(deletedBirdID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new DeleteBirdByIDCommand(deletedBirdID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}