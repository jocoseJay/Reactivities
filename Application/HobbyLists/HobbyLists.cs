using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.HobbyLists
{
    //It defines a Query Executioner and handler.
    // The Handler will be called by the controller
    //The handler inturns calls the query executioner 
    public class HobbyLists
    {
        public class Query : IRequest<List<Activity>>{}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
              private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                 _dataContext = dataContext;
            }


            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Activities.ToListAsync();
            }
        }
    }
}