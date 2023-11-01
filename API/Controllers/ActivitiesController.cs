using Application.HobbyLists;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{

    public class ActivitiesController : BaseApiController
    {

        public IMediator _mediator { get; }

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet] 
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //return Ok();
            return await _mediator.Send(new HobbyLists.Query());
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Activity>> GetActivitiy(Guid id)
        {
            return Ok();
        }




    }
}