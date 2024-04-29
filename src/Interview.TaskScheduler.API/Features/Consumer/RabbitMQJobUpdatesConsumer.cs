using Interview.TaskScheduler.API.Features.Hubs;
using Interview.TaskScheduler.Shared.Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace Interview.TaskScheduler.API.Features.Consumer
{
    public class RabbitMQJobUpdatesConsumer : IConsumer<JobUpdate>
    {
        private readonly IHubContext<JobsHub> _jobsHub;

        public RabbitMQJobUpdatesConsumer(IHubContext<JobsHub> jobsHub)
        {
            _jobsHub = jobsHub;
        }
        public async Task Consume(ConsumeContext<JobUpdate> context)
        {
            await _jobsHub.Clients.Client(context.Message.ClientId).SendAsync("JobUpdates", context.Message);
        }
    }
}
