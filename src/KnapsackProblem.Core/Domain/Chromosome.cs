using System.Text;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Core.Domain;

/// <summary>
/// Reprezentacja chromosomu/osobnika populacji.
/// </summary>
public class Chromosome(Gene[] genes)
{
    /// <summary>
    /// Geny chromosomu.
    /// </summary>
    public Gene[] Genes
        => genes;

    /// <summary>
    /// Rozmiar chromosomu.
    /// </summary>
    public Size Size
        => Genes.Length;

    /// <summary>
    /// Zwraca losowo wygenerowany chromosom o podanym rozmiarze.
    /// </summary>
    /// <param name="size">Rozmiar chromosomu.</param>
    public static Chromosome CreateRandom(Size size)
        => new Chromosome(Enumerable.Range(1, size).Select(i => Gene.CreateRandom()).ToArray());

    private bool _evaluated = false;
    private Fitness _fitness = Fitness.Default;

    /// <summary>
    /// Wartość przystosowania chromosomu.
    /// </summary>
    public Fitness Fitness
    {
        get
        {
            if (!_evaluated)
                throw new InvalidOperationException($"The chromosome has not been evaluated. Run the '{nameof(Evaluate)}' method first.");

            return _fitness;
        }
    }

    /// <summary>
    /// Wylicza wartość przystosowania chromosomu.
    /// </summary>
    /// <param name="evaluator">Obiekt wyliczający</param>
    public void Evaluate(IEvaluator evaluator)
    {
        _fitness = evaluator.Evaluate(genes);
        _evaluated = true;
    }

    /// <summary>
    /// Mutuje aktualny chromosom i zwraca jako nowy.
    /// </summary>
    /// <param name="mutator">Obiekt mutujący.</param>
    public Chromosome Mutate(IMutator mutator)
        => new(mutator.Mutate(genes));
    
    /// <summary>
    /// Umożliwia sklonowanie bieżącego obiektu chromosomu.
    /// </summary>
    /// <returns></returns>
    public Chromosome Clone()
        => new (genes)
        {
            _fitness = _fitness,
            _evaluated = _evaluated
        };

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Genes: [{string.Join(", ", genes)}]");

        if (_evaluated)
            sb.AppendLine($"{Fitness}");
        else
            sb.AppendLine("The fitness is not evaluated");

        return sb.ToString();
    }
}
