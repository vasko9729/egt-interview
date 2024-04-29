
using Interview.TaskScheduler.Shared.Contracts;

namespace Interview.TaskScheduler.Features.TaskScheduler;

public interface ITaskSchedulerService
{
    Task ScheduleNewTask(Job job);
}
