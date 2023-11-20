using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.Dogs;
using Application.Queries.Dogs.GetDogByID;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        public DogsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        // Detta är APi endpoint där vi hämtar alla hundar från MockDatabase
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            // Använda medator
            // MediatR ska ta emot requests och dela de på Commands eller Queries
            // Detta är en GET då blir det en Query

            return Ok(await _mediatR.Send(new GetAllDogsQuery()));
        }

        [HttpGet]
        [Route("getDogById/{dogID}")]
        public async Task<IActionResult> GetDogById(Guid dogID)
        {
            return Ok(await _mediatR.Send(new GetDogByIDQuery(dogID)));
            Console.WriteLine("nemo");
        }
    }
}