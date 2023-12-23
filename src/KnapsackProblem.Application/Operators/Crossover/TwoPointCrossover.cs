using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Domain;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Application.Operators.Crossover;

/// <summary>
/// Krzyżowanie dwupunktowe.
/// </summary>
/// <remarks>
/// W tej metodzie losowo wybiera się dwa punkty podziału na chromosomach rodziców.
/// Geny między punktami podziału są wymieniane między rodzicami.
/// </remarks>
public class MultiPointCrossover(Rate rate) : ICrossover
{
    private Random _random = new();

    public IEnumerable<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
    {
        var genesParent1 = parent1.Genes;
        var genesParent2 = parent2.Genes;

        // Jeśli krzyżowanie nie zachodzi to jako dzieci zwracamy rodziców.
        if (_random.NextDouble() >= rate)
            return new Chromosome[] { new (genesParent1), new (genesParent2) };
            
        int size = parent1.Size;

        int crossoverPoint1 = 0;
        int crossoverPoint2 = 0;

        while(crossoverPoint1 >= crossoverPoint2)
        {
            // Losowe wybranie dwóch punktów krzyżowania.
            crossoverPoint1 = _random.Next(1, size);
            crossoverPoint2 = _random.Next(1, size);
        }

        var genesChild1 = new Gene[genesParent1.Length];
        var genesChild2 = new Gene[genesParent2.Length];

        // Kopiowanie genów
        for (int i = 0; i < size; i++)
        {
            if (i < crossoverPoint1 || i >= crossoverPoint2)
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
