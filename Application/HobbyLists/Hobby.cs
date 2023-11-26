using Domain;
using MediatR;
using Persistence;

namespace Application.HobbyLists
{
    public class Hobby
    {
        public class Query : IRequest<Activity>
        {
               public Guid Id {get;set;}
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext m_DataContext;

            public Handler(DataContext dataContext)
            {
                m_DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await m_DataContext.Activities.FindAsync(request.Id);
            }
        }
    }
}