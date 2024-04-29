namespace Interview.TaskScheduler.Features.Producer;

public interface IProducer<TMassege>
{
    Task ProduceAsync(TMassege massege);
}
