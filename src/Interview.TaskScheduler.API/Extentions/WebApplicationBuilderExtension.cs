using Interview.TaskScheduler.API.Configurations;
using Interview.TaskScheduler.API.Features.Producer;
using Interview.TaskScheduler.API.Features.Producer.Impementations;
using Interview.TaskScheduler.Shared.Contracts;
using MassTransit;

namespace Interview.TaskScheduler.API.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection(nameof(RabbitMQConfiguration)));

        return builder;
    }

    public static WebApplicationBuilder AddRabbitMQ(this WebApplicationBuilder builder)
    {
        var rabbitMqConfiguration = builder.Configuration.GetSection(nameof(RabbitMQConfiguration)).Get<RabbitMQConfiguration>();

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(Program).Assembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqConfiguration!.Uri, "/", c =>
                {
                    c.Username(rabbitMqConfiguration.UserName);
                    c.Password(rabbitMqConfiguration.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return builder;
    }

    public static WebApplicationBuilder AddRabbitMQProducer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProducer<Job>, RabbitMQProducer<Job>>(); 

        return builder;
    }
}
