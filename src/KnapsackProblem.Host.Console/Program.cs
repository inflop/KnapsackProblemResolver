using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CommandLine;
using KnapsackProblem.Application;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Host.Console;
using KnapsackProblem.Core.Parameters;

Parameters? parameters = null;
Parser.Default.ParseArguments<Parameters>(args)
                .WithParsed(p =>
                {
                    p.Validate();
                    parameters = p;
                });

if (parameters is null)
    Environment.Exit(-1);

await Host.CreateDefaultBuilder(args)
          .UseConsoleLifetime()
          .ConfigureLogging((_, loggingBuilder) =>
          {
              loggingBuilder.ClearProviders();
              loggingBuilder.AddConsole();
          })
          .ConfigureServices((_, services) =>
          {
              services.AddSingleton<IParameters>(parameters);
              services.AddKnapsackProblemResolver();
              services.AddHostedService<MainService>();
          })
          .RunConsoleAsync();

