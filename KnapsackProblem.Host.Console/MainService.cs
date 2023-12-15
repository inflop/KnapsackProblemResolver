using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Host.Console;

public class MainService(IParameters parameters, IProblemResolver resolver, ILogger<MainService> logger,
                         IHostApplicationLifetime hostApplicationLifetime) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        hostApplicationLifetime.ApplicationStarted.Register(() =>
        {
            try
            {
                logger.LogInformation($"============= Parameters =============\n{parameters}");
                logger.LogInformation($"Problem resolver started...");

                var resolveResult = resolver.Resolve(parameters);

                logger.LogInformation($"Problem resolver stopped.");
                logger.LogInformation($"============= Summary =============\n{resolveResult}");
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
            }
            finally
            {
                hostApplicationLifetime.StopApplication();
            }
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
