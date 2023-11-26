using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.HobbyLists
{
    public class EditHobby
    {
        
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext m_DataContext;
             private IMapper m_Mapper;

            public Handler(DataContext dataContext, IMapper mapper)
            {
                 m_Mapper = mapper;
                 m_DataContext = dataContext;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                Activity activity = await m_DataContext.Activities.FindAsync(request.Activity.Id);
                m_Mapper.Map(request.Activity, activity);
                await m_DataContext.SaveChangesAsync();
            }
        }
    }
}