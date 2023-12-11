using Application.Commands.Animals.Cats.AddCat;
using Application.Commands.Animals.Cats.DeleteCat;
using Application.Commands.Animals.Cats.UpdateCat;
using Application.Dtos.AnimalsDtos.CatDto;
using Application.Queries.Animals.Cats.GetAllCats;
using Application.Queries.Animals.Cats.GetCatByID;
using Application.Validators;
using Application.Validators.Cat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        internal readonly GuidValidator _guidValidator;
        internal readonly CatValidator _catValidator;
        public CatsController(IMediator mediatR, GuidValidator guidValidator, CatValidator catValidator)
        {
            _mediatR = mediatR;
            _guidValidator = guidValidator;
            _catValidator = catValidator;
        }

        // Detta är APi endpoint där vi hämtar alla hundar från MockDatabase
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            try
            {
                return Ok(await _mediatR.Send(new GetAllCatsQuery()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getCatById/{catID}")]
        public async Task<IActionResult> GetCatById(Guid catID)
        {
            var guidToValidate = _guidValidator.Validate(catID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new GetCatByIDQuery(catID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new Cat 
        [HttpPost]
        [Authorize]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            // Validate Cat
            var catToValidate = _catValidator.Validate(newCat);

            // Error handling
            if (!catToValidate.IsValid)
            {
                return BadRequest(catToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try catch
            try
            {
                return Ok(await _mediatR.Send(new AddCatCommand(newCat)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific Cat
        [HttpPut]
        [Authorize]
        [Route("updateCat/{updatedcatID}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedcatID)
        {
            // Validate Cat
            var catToValidate = _catValidator.Validate(updatedCat);

            // Error handling
            if (!catToValidate.IsValid)
            {
                return BadRequest(catToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try catch
            try
            {
                return Ok(await _mediatR.Send(new UpdateCatByIDCommand(updatedCat, updatedcatID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete a specific Cat
        [HttpDelete]
        [Authorize]
        [Route("deleteCat/{deletedCatID}")]
        public async Task<IActionResult> DeleteCat(Guid deletedCatID)
        {
            var guidToValidate = _guidValidator.Validate(deletedCatID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new DeleteCatByIDCommand(deletedCatID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}