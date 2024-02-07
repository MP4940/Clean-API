using Application.Commands.Animals.Dogs.AddDog;
using Application.Commands.Animals.Dogs.DeleteDog;
using Application.Commands.Animals.Dogs.UpdateDog;
using Application.Dtos.AnimalsDtos.DogDto;
using Application.Queries.Animals.Dogs.GetAllDogs;
using Application.Queries.Animals.Dogs.GetDogByID;
using Application.Queries.Animals.Dogs.GetDogsByWeightBreed;
using Application.Validators;
using Application.Validators.Dog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        internal readonly GuidValidator _guidValidator;
        internal readonly DogValidator _dogValidator;
        public DogsController(IMediator mediatR, GuidValidator guidValidator, DogValidator dogValidator)
        {
            _mediatR = mediatR;
            _guidValidator = guidValidator;
            _dogValidator = dogValidator;
        }

        // Detta är APi endpoint där vi hämtar alla hundar från MockDatabase
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            try
            {
                return Ok(await _mediatR.Send(new GetAllDogsQuery()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getDogById/{dogID}")]
        public async Task<IActionResult> GetDogById(Guid dogID)
        {
            var guidToValidate = _guidValidator.Validate(dogID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new GetDogByIDQuery(dogID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getDogByWeightBreed")]
        public async Task<IActionResult> GetDogsByWeightBreed(int? weight, string? breed)
        {
            try
            {
                var dogs = await _mediatR.Send(new GetDogsByWeightBreedQuery { Weight = weight, Breed = breed });
                return Ok(dogs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new dog 
        [HttpPost]
        //[Authorize]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            // Validate dog
            var dogToValidate = _dogValidator.Validate(newDog);

            // Error handling
            if (!dogToValidate.IsValid)
            {
                return BadRequest(dogToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try catch
            try
            {
                return Ok(await _mediatR.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog
        [HttpPut]
        //[Authorize]
        [Route("updateDog/{updatedDogID}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogID)
        {
            // Validate dog
            var dogToValidate = _dogValidator.Validate(updatedDog);

            // Error handling
            if (!dogToValidate.IsValid)
            {
                return BadRequest(dogToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try catch
            try
            {
                return Ok(await _mediatR.Send(new UpdateDogByIDCommand(updatedDog, updatedDogID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific dog
        [HttpDelete]
        //[Authorize]
        [Route("deleteDog/{deletedDogID}")]
        public async Task<IActionResult> DeleteDog(Guid deletedDogID)
        {
            var guidToValidate = _guidValidator.Validate(deletedDogID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new DeleteDogByIDCommand(deletedDogID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}