using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            // This is what we want to receive as a parameter from our API
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {            
            private readonly DataContext _context;

            // Inject DataContext
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

                return Unit.Value; // Equivalent to nothing. Just a way letting our API controller know that we finished what was going on inside here.
            }
        }
    }
}