using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
               
                var activities = await _context.Activities.ToListAsync();

                return activities;
            }

            // Using Caleling request
            // public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            // {
            //     try
            //     {
            //         for (int i = 0; i < 10; i++)
            //         {
            //             cancellationToken.ThrowIfCancellationRequested();
            //             await Task.Delay(1000, cancellationToken);
            //             _logger.LogInformation($"Task {i} has completed");
            //         }
            //     }
            //     catch (Exception ex) when (ex is TaskCanceledException)
            //     {
            //         _logger.LogInformation($"Task was canceled");
            //     }
            //     // throw new System.NotImplementedException();
            //     var activities = await _context.Activities.ToListAsync(cancellationToken);

            //     return activities;
            // }
        }
    }
}