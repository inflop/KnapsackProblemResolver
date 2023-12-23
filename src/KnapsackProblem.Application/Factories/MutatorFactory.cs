using KnapsackProblem.Application.Operators;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Factories;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Application.Factories;

public class MutatorFactory : IMutatorFactory
{
    public IMutator Create(Rate mutationRate)
        => new Mutator(mutationRate);
}
