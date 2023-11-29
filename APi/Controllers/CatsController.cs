using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.Animals.Cats.GetAllCats;
using Application.Queries.Animals.Cats.GetCatByID;
using Application.Commands.Animals.Cats.AddCat;
using Application.Commands.Animals.Cats.UpdateCat;
using Application.Dtos.AnimalsDtos.CatDto;
using Application.Commands.Animals.Cats.DeleteCat;
using Microsoft.AspNetCore.Authorization;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        public CatsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        // Detta är APi endpoint där vi hämtar alla hundar från MockDatabase
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            // Använda medator
            // MediatR ska ta emot requests och dela de på Commands eller Queries
            // Detta är en GET då blir det en Query

            return Ok(await _mediatR.Send(new GetAllCatsQuery()));
        }

        [HttpGet]
        [Route("getCatById/{catID}")]
        public async Task<IActionResult> GetCatById(Guid catID)
        {
            return Ok(await _mediatR.Send(new GetCatByIDQuery(catID)));
        }

        // Create a new Cat 
        [HttpPost]
        [Authorize]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediatR.Send(new AddCatCommand(newCat)));
        }

        // Update a specific Cat
        [HttpPut]
        [Authorize]
        [Route("updateCat/{updatedCatID}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatID)
        {
            return Ok(await _mediatR.Send(new UpdateCatByIDCommand(updatedCat, updatedCatID)));
        }

        // Delete a specific Cat
        [HttpDelete]
        [Authorize]
        [Route("deleteCat/{deletedCatID}")]
        public async Task<IActionResult> DeleteCat(Guid deletedCatID)
        {
            return Ok(await _mediatR.Send(new DeleteCatByIDCommand(deletedCatID)));
        }
    }
}