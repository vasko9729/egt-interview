namespace Interview.TaskScheduler.API.Features.Producer;

public interface IProducer<TMassege>
{
    Task ProduceAsync(TMassege massege);
}
