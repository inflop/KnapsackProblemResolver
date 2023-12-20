using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;

namespace KnapsackProblem.Application;

/// <summary>
/// Krzyżowanie jednorodne.
/// </summary>
/// <remarks>
/// W tej metodzie każdy gen jest niezależnie wybierany od jednego z rodziców z określonym prawdopodobieństwem.
/// To pozwala na bardziej równomierną wymianę informacji genetycznej.
/// </remarks>
public class UniformCrossover(Rate rate) : ICrossover
{
    private Random _random = new();

    public IEnumerable<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
    {
        var genesParent1 = parent1.Genes;
        var genesParent2 = parent2.Genes;

        // Jeśli krzyżowanie nie zachodzi to jako dzieci zwracamy rodziców.
        if (_random.NextDouble() >= rate)
            return new Chromosome[] { new (genesParent1), new (genesParent2) };

        var genesChild1 = new Gene[genesParent1.Length];
        var genesChild2 = new Gene[genesParent2.Length];

        for (int i = 0; i < parent1.Size; i++)
        {
            if (_random.NextDouble() < rate)
            {
                genesChild1[i] = genesParent1[i];
                genesChild2[i] = genesParent2[i];
            }
            else
            {
                genesChild1[i] = genesParent2[i];
                genesChild2[i] = genesParent1[i];
            }
        }

        return new Chromosome[] { new (genesChild1), new (genesChild2) };
    }
}
