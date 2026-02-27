using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities.Queries;
using Application.Activities.Commands;
using Activity = Domain.Activity;

namespace API.Controllers;

public class ActivitiesController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<String>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command { activity = activity });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditActivity(string id, Activity activity)
    {
        activity.Id = id;
        await Mediator.Send(new Application.Activities.Commands.EditActivity.Command { activity = activity });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new Application.Activities.Commands.DeleteActivity.Command { Id = id });
        return Ok();
    }
}
