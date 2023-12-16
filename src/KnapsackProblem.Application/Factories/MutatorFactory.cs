using KnapsackProblem.Application.Operators;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Factories;
using KnapsackProblem.Core.Abstractions.Operators;

namespace KnapsackProblem.Application;

public class MutatorFactory : IMutatorFactory
{
    public IMutator Create(Rate mutationRate)
        => new Mutator(mutationRate);
}
