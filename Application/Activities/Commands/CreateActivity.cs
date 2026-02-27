using System;
using System.Diagnostics;
using MediatR;
using Persistence;
using Activity = Domain.Activity;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<String>
    {
        public required Activity activity { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, String>
    {
        public async Task<String> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.activity);
            await context.SaveChangesAsync(cancellationToken);
            return request.activity.Id;
        }
    }
}

