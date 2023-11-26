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
        
        [HttpGet] 
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new HobbyLists.Query());
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Activity>> GetActivitiy(Guid id)
        {
            return await Mediator.Send(new Hobby.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateHobby([FromBody] Activity activity)
        {
            await Mediator.Send(new CreateHobby.Command{ Activity = activity});
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHobby(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new EditHobby.Command{ Activity =activity});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHobby(Guid id)
        {
            await Mediator.Send(new HobbyDelete.Command{ Guid =id});
            return Ok();
        }
    }
}