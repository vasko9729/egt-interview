namespace Interview.TaskScheduler.Shared.Contracts;

public class JobUpdate
{
    public string JobId { get; set; }

    public string ClientId { get; set; }

    public double LoadingPercents { get; set; }
}
