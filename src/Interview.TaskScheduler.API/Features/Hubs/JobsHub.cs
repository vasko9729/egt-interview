using Interview.TaskScheduler.API.Features.Producer;
using Interview.TaskScheduler.Shared.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace Interview.TaskScheduler.API.Features.Hubs;

public class JobsHub : Hub
{
    private readonly IProducer<Job> _producer;

    public JobsHub(IProducer<Job> producer)
    {
        _producer = producer;
    }
    public override Task OnConnectedAsync()
    {
        
        return base.OnConnectedAsync();
    }

    public async Task ScheduleNewJob()
    {
        var job = new Job()
        {
            Id = Guid.NewGuid().ToString(),
            ClientId = Context.ConnectionId
        };

        await _producer.ProduceAsync(job);
    }
}
