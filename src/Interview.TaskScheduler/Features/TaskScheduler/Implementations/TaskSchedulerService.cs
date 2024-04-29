using Interview.TaskScheduler.Features.Producer;
using Interview.TaskScheduler.Shared.Contracts;

namespace Interview.TaskScheduler.Features.TaskScheduler.Implementations;

public class TaskSchedulerService : ITaskSchedulerService
{
    private readonly IProducer<JobUpdate> _producer;

    public TaskSchedulerService(IProducer<JobUpdate> producer)
    {
        _producer = producer;
    }

    public async Task ScheduleNewTask(Job job)
        => await ExecuteJob(job);

    private async Task ExecuteJob(Job job)
    {
        await Task.Yield();

        for (int i = 0; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                var jobUpdate = new JobUpdate()
                {
                    JobId = job.Id,
                    ClientId = job.ClientId,
                    LoadingPercents = i
                };

                await _producer.ProduceAsync(jobUpdate);
                await Task.Delay(100);
            }
        }
    }
}
