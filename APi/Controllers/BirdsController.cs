using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.Animals.Birds.GetAllBirds;
using Application.Queries.Animals.Birds.GetBirdByID;
using Application.Commands.Animals.Birds.AddBird;
using Application.Dtos.AnimalsDtos.BirdDto;
using Application.Commands.Animals.Birds.UpdateBird;
using Application.Commands.Animals.Birds.DeleteBird;
using Microsoft.AspNetCore.Authorization;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        public BirdsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            // Använda medator
            // MediatR ska ta emot requests och dela de på Commands eller Queries
            // Detta är en GET då blir det en Query

            return Ok(await _mediatR.Send(new GetAllBirdsQuery()));
        }

        [HttpGet]
        [Route("getBirdById/{BirdID}")]
        public async Task<IActionResult> GetBirdById(Guid BirdID)
        {
            return Ok(await _mediatR.Send(new GetBirdByIDQuery(BirdID)));
        }

        // Create a new Bird 
        [HttpPost]
        [Authorize]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediatR.Send(new AddBirdCommand(newBird)));
        }

        // Update a specific Bird
        [HttpPut]
        [Authorize]
        [Route("updateBird/{updatedBirdID}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdID)
        {
            return Ok(await _mediatR.Send(new UpdateBirdByIDCommand(updatedBird, updatedBirdID)));
        }

        // Delete a specific Bird
        [HttpDelete]
        [Authorize]
        [Route("deleteBird/{deletedBirdID}")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdID)
        {
            return Ok(await _mediatR.Send(new DeleteBirdByIDCommand(deletedBirdID)));
        }
    }
}