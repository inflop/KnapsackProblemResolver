using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CommandLine;
using KnapsackProblem.Application;
using KnapsackProblem.Host.Console;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Parameters;

Parameters? parameters = null;
Parser.Default.ParseArguments<Parameters>(args)
                .WithParsed(p =>
                {
                    if (!File.Exists(p.InputFile))
                        throw new FileNotFoundException(Path.GetFullPath(p.InputFile!));

                    if (p.MutationRate < Rate.Min || p.MutationRate > Rate.Max)
                        throw new ArgumentOutOfRangeException($"The value for {nameof(p.MutationRate)} must be between {Rate.Min} and {Rate.Max}.");

                    if (p.CrossoverRate < Rate.Min || p.CrossoverRate > Rate.Max)
                        throw new ArgumentOutOfRangeException($"The value for {nameof(p.CrossoverRate)} must be between {Rate.Min} and {Rate.Max}.");

                    if (p.KnapsackSize < Size.Min || p.KnapsackSize > Size.Max)
                        throw new ArgumentOutOfRangeException($"The value for {nameof(p.KnapsackSize)} must be between {Size.Min} and {Size.Max}.");

                    if (p.PopulationSize < Size.Min || p.PopulationSize > Size.Max)
                        throw new ArgumentOutOfRangeException($"The value for {nameof(p.PopulationSize)} must be between {Size.Min} and {Size.Max}.");

                    parameters = p;
                });

if (parameters is null)
    Environment.Exit(-1);

await Host.CreateDefaultBuilder(args)
          .UseConsoleLifetime()
          .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
          {
              loggingBuilder.ClearProviders();
              loggingBuilder.AddConsole();
          })
          .ConfigureServices((hostBuilderContext, services) =>
          {
              services.AddSingleton<IParameters>(parameters);
              services.AddKnapsackProblemResolver();
              services.AddHostedService<MainService>();
          })
          .RunConsoleAsync();

