using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;

namespace KnapsackProblem.Application.Operators.Selection;

/// <summary>
/// W tym podejściu każdy z osobników otrzymuje rangę,
/// która jest wyznaczana na podstawie wartości funkcji oceny.
/// Najprostszym sposobem nadania rang jest po prostu posortowanie osobników
/// w kolejności niemalejącej od największej do najniższej wartości przystosowania.
/// Rangi są kolejnymi numerami osobników w takim uszeregowaniu.
/// W przypadku wystąpienia osobników o tej samej wartości oceny możemy postąpić dwojako:
/// - albo nadać kolejny numer zgodnie z uszeregowaniem – wtedy osobniki otrzymają inne rangi,
/// - albo nadać im tą samą rangę.
/// Rangi są zatem liczbami całkowitymi nieujemnymi (rangi nadajemy od 0).
/// Ranga nadana osobnikowi wykorzystywana jest w funkcji,
/// która definiuje jakie prawdopodobieństwo wylosowania ma zostać mu nadane.
/// Funkcja ta jest najczęściej liniowa.
/// </summary>
public class RankSelector : ISelector
{
    private readonly Random _random = new();

    public Chromosome Select(Population population)
        => Select2(population);

    private Chromosome Select1(Population population)
    {
        var chromosomes = population.Chromosomes.ToArray();
        var sortedList = chromosomes.OrderByDescending(chromosome => chromosome.Fitness.Value).ToArray();
        
        double totalRank = chromosomes.Length * (chromosomes.Length + 1) / 2d;
        double randomValue = _random.NextDouble() * totalRank;
        double sum = 0;
        int rank = 1;
        
        foreach (var chromosome in sortedList)
        { 
            sum += rank;
            if (sum >= randomValue)
                return chromosome.Clone();
        
            rank++;
        }
        
        return population.BestChromosome!.Clone();
    }

    private Chromosome Select2(Population population)
    {
        var chromosomes = population.Chromosomes.ToArray();
        var sorted = chromosomes.OrderByDescending(chromosome => chromosome.Fitness.Value).ToArray();
        var totalRank = (sorted.Length * (sorted.Length + 1)) / 2;
        
        var rankWheel = new List<double>();
        var cumulativeRank = 0d;
        
        for (var n = sorted.Length; n > 0; n--)
        {
            cumulativeRank += (double)n / totalRank;
            rankWheel.Add(cumulativeRank);
        }
        
        var randomValue = _random.NextDouble() * totalRank;
        var valueIndex = rankWheel
            .Select((value, index) => new { Value = value, Index = index })
            .FirstOrDefault(r => r.Value >= randomValue);
        
        if (valueIndex is null)
            return population.BestChromosome!;
        
        var chromosome = sorted[valueIndex.Index].Clone();
        
        return chromosome;        
    }
}
