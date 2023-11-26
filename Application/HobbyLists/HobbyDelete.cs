using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.HobbyLists
{
    public class HobbyDelete
    {
        public class Command : IRequest
        {
            public Guid Guid { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
           private  DataContext m_DataContext { get; }
            
            public Handler(DataContext dataContext)
            {
                 m_DataContext = dataContext;
     
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
               var hobby = await m_DataContext.Activities.FindAsync(request.Guid);
               m_DataContext.Remove(hobby);
               await m_DataContext.SaveChangesAsync();
            }
        }
    }
}