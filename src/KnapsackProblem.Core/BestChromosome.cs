using System.Text;

namespace KnapsackProblem.Core;

/// <summary>
/// Rekord reprezentujący informacje o najlepszym chromosomie.
/// </summary>
/// <param name="Iteration">Numer iteracji, w której algorytm odnalazł chromosom.</param>
/// <param name="Genes">Geny chromosomu.</param>
/// <param name="Fitness">Wartość przystosowania chromosomu.</param>
public record BestChromosome(int Iteration, Gene[] Genes, Fitness Fitness)
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"[{string.Join(", ", Genes)}]");
        sb.AppendLine($"{Fitness}");
        sb.Append($"Found in iteration: {Iteration}");
        return sb.ToString();
    }
}
