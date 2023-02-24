using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // This is using dependency injection. Any time a new HTTP request comes in
        // and our Program class knows where this request needs to go its going to send
        // it to the ActivitiesController and it's going to create a new instance
        // and it will create a new instance of the DataContext and that will be available
        // inside of this class.
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;            
        }

        // These are two end points

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/guid_goes_here
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}