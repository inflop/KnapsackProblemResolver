using KnapsackProblem.Application.Operators.Crossover;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Factories;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Application.Factories;

public class CrossoverFactory : ICrossoverFactory
{
    public ICrossover Create(CrossoverParameters parameters)
        => parameters.Type switch
        {
            CrossoverType.OnePoint => new OnePointCrossover(parameters.Rate),
            CrossoverType.TwoPoint => new MultiPointCrossover(parameters.Rate),
            CrossoverType.Uniform => new UniformCrossover(parameters.Rate),
            _ => throw new ArgumentException("Invalid crossover type", nameof(parameters.Type)),
        };
}
