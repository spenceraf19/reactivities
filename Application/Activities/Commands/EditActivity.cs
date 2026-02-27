using System;
using MediatR;
using Domain;
using Activity = Domain.Activity;
using Persistence;
using System.ComponentModel.Design.Serialization;
using AutoMapper;

namespace Application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity activity { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                .FindAsync([request.activity.Id], cancellationToken)
                    ?? throw new Exception("Activity not found");
        
            mapper.Map(request.activity, activity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
