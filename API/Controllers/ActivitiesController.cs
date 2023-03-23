using Domain;
using MediatR;
using Application.Activities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // These are end points

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/activities/guid_goes_here
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            //Object initializor syntax {Id = id} this gets set when we initialize this class
            return await Mediator.Send(new Details.Query{Id = id});
        }

        // IActionResult gives us access to Http response types like Http OK, bad request, not found
        // When we send up a body of the request, because of the [APIController] attribute on the BaseApiController
        // it's going to be smart enough to recognize that it needs to look inside the body of the request 
        // to get this Activity object and it'll compare the properties available in the activity and if they match
        // it'll say AHA this is an activity that you want to pass as a parameter and i'll look inside the body to get it
        // You can give it a hint via CreateActivity([FromBody]Activity activity) to tell the API controller specifically 
        // where to find this but b/c of the attribute above we don't need to do this.
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        }

        // [HttpPut] updates resources
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}