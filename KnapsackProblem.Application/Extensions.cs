using Microsoft.Extensions.DependencyInjection;
using KnapsackProblem.Application.Factories;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Abstractions.Factories;

namespace KnapsackProblem.Application;

public static class Extensions
{
    public static IServiceCollection AddKnapsackProblemResolver(this IServiceCollection services)
    {
        services.AddSingleton<IEvaluatorFactory, EvaluatorFactory>();
        services.AddSingleton<ICrossoverFactory, CrossoverFactory>();
        services.AddSingleton<ISelectorFactory, SelectorFactory>();
        services.AddSingleton<IMutatorFactory, MutatorFactory>();
        services.AddSingleton<IBestChromosomeProvider, BestChromosomeProvider>();
        services.AddSingleton<IIterationController, IterationController>();
        services.AddSingleton<IProblemResolver, ProblemResolver>();
        return services;
    }
}
