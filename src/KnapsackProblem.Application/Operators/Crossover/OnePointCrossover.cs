using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Domain;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Application.Operators.Crossover;

/// <summary>
/// Krzyżowanie jednopunktowe.
/// </summary>
/// <remarks>
/// W tej metodzie losowo wybiera się pojedynczy punkt podziału na chromosomach rodziców.
/// Geny po jednej stronie punktu są wymieniane między dwoma rodzicami, tworząc dwa nowe chromosomy.
/// </remarks>
public class OnePointCrossover(Rate rate) : ICrossover
{
    private Random _random = new();

    public IEnumerable<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
    {
        var genesParent1 = parent1.Genes;
        var genesParent2 = parent2.Genes;

        // Jeśli krzyżowanie nie zachodzi to jako dzieci zwracamy rodziców.
        if (_random.NextDouble() > rate)
            return new Chromosome[] { new (genesParent1), new (genesParent2) };

        // Losowe wyznaczenie indeksu będącego punktem przecięcia.
        int crossoverPoint = _random.Next(1, parent2.Size - 1);

        var genes1 = SplitChromosomeAtPoint(crossoverPoint, parent1);
        var genes2 = SplitChromosomeAtPoint(crossoverPoint, parent2);

		var genes1_1 = genes1.part1; // pierwsza część chromosomu pierwszego rodzica.
		var genes1_2 = genes1.part2; // druga część chromosomu pierwszego rodzica.
		
		var genes2_1 = genes2.part1; // pierwsza część chromosomu drugiego rodzica.
		var genes2_2 = genes2.part2; // druga część chromosomu drugiego rodzica.

        var genesChild1 = genes1_1.Concat(genes2_2).ToArray();
        var genesChild2 = genes2_1.Concat(genes1_2).ToArray();

        return new Chromosome[] { new (genesChild1), new (genesChild2) };
    }

    /// <summary>
    /// Dzieli chromosom we wskazanym punkcie i zwraca dwie tablice genów.
    /// </summary>
    /// <param name="point">Punkt dzielenia chromosomu</param>
    /// <param name="chromosome">Chromosom do podziału</param>
    /// <returns></returns>
    private (Gene[] part1, Gene[] part2) SplitChromosomeAtPoint(int point, Chromosome chromosome)
    {
		var part1 = Enumerable.Range(0, point).Select(i => chromosome.Genes[i]).ToArray();
		var part2 = Enumerable.Range(point, chromosome.Genes.Length-part1.Length).Select(i => chromosome.Genes[i]).ToArray();
        return (part1, part2);
    }
}
