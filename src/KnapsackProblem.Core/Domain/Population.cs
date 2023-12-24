using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Core.Domain;

/// <summary>
/// Struktura będąca reprezentacją populacji
/// </summary>
public struct Population
{
    private readonly IList<Chromosome> _chromosomes;

    public Population()
        => _chromosomes = new List<Chromosome>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="chromosomes"></param>
    private Population(IEnumerable<Chromosome> chromosomes)
        => _chromosomes = chromosomes.ToList();

    /// <summary>
    /// 
    /// </summary>
    public Chromosome? BestChromosome { get; private set; }

    /// <summary>
    /// Lista osobników w populacji.
    /// </summary>
    public readonly IEnumerable<Chromosome> Chromosomes
        => _chromosomes;

    /// <summary>
    /// Rozmiar populacji
    /// </summary>
    public readonly Size Size
        => Chromosomes.Count();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="chromosome"></param>
    public void AddChromosome(Chromosome chromosome)
        => _chromosomes.Add(chromosome);

    /// <summary>
    /// Tworzy populację o podanym rozmiarze z losowo utworzonych osobników,
    /// z których każdy ma rozmiar chromosomu przekazany w parametrze.
    /// </summary>
    /// <param name="populationSize">Rozmiar populacji do utworzenia</param>
    /// <param name="chromosomeSize">Rozmiar chromosomu osobnika tworzonej populacji</param>
    public static Population CreateRandom(Size populationSize, Size chromosomeSize)
        => new (Enumerable.Range(1, populationSize).Select(_ => Chromosome.CreateRandom(chromosomeSize)));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="evaluator"></param>
    public void Evaluate(IEvaluator evaluator)
    {
        foreach (var chromosome in Chromosomes)
            chromosome.Evaluate(evaluator);

        BestChromosome = Chromosomes.MaxBy(c => c.Fitness.Value);
    }

    public override string ToString()
        => string.Join("\n", _chromosomes);
}
