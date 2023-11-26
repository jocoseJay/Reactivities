using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.HobbyLists
{
    public class CreateHobby
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
             private readonly DataContext _DataContext;

             public Handler(DataContext dataContext)
             {
                 _DataContext = dataContext;
             }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _DataContext.Activities.Add(request.Activity);
                await _DataContext.SaveChangesAsync();
            }
        }
    }
}