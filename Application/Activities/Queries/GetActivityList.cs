using System;
using System.Diagnostics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using Activity = Domain.Activity;

namespace Application.Activities.Queries;

public class GetActivityList
{
    public class Query  : IRequest<List<Activity>> {}

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {

            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
