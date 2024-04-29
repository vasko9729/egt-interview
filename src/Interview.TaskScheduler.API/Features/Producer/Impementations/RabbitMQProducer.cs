
using MassTransit;

namespace Interview.TaskScheduler.API.Features.Producer.Impementations;

public class RabbitMQProducer<TMessege> : IProducer<TMessege>
{
    private readonly IBus _bus;

    public RabbitMQProducer(IBus bus)
    {
        _bus = bus;
    }

    public async Task ProduceAsync(TMessege messege)
    {
        await _bus.Publish(messege);
    }
}
