using Interview.TaskScheduler.Features.TaskScheduler;
using Interview.TaskScheduler.Shared.Contracts;
using MassTransit;

namespace Interview.TaskScheduler.Features.Consumer;

public class RabbitMQJobsConsumer : IConsumer<Job>
{
    private readonly ITaskSchedulerService _taskSchedulerService;

    public RabbitMQJobsConsumer(ITaskSchedulerService taskSchedulerService)
    {
        _taskSchedulerService = taskSchedulerService;
    }
    public async Task Consume(ConsumeContext<Job> context)
    {
        await _taskSchedulerService.ScheduleNewTask(context.Message);
    }
}
