using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Domain;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Application.Operators;

public class Mutator(Rate mutationRate) : IMutator
{
    private readonly Random _random = new();

    public Gene[] Mutate(Gene[] genes)
    {
        var mutatedGenes = genes.Select(gene =>
        {
            if (_random.NextDouble() < mutationRate)
                return gene.Mutate();

            return gene;
        });

        return mutatedGenes.ToArray();
    }
}
