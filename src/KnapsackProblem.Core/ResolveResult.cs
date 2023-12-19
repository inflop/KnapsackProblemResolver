using System.Text;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Core;

/// <summary>
/// Rekord reprezentujący rezultat rozwiązania algorytmu.
/// </summary>
/// <param name="TotalIterations">Ilość wszystkich iteracji pętli.</param>
/// <param name="BestChromosome">Najlepszy chromosom.</param>
/// <param name="History">Historia najlepszych chromosomów populacji w ramach wszystkich iteracji rozwiązania.</param>
/// <param name="ElapsedTime">Czas pracy algorytmu, czas trwania poszukiwania rozwiązania.</param>
public record struct ResolveResult(int TotalIterations, BestChromosome BestChromosome, 
    IEnumerable<BestChromosome> History, TimeSpan ElapsedTime, IParameters Parameters)
{
    public override string ToString()
    {
        string elapsedTime = $"{ElapsedTime.Hours:00}:{ElapsedTime.Minutes:00}:{ElapsedTime.Seconds:00}.{ElapsedTime.Milliseconds:000}";
        var sb = new StringBuilder();
        sb.AppendLine($"Total iterations: {TotalIterations}");
        sb.AppendLine($"Time elapsed: {elapsedTime}");
        sb.Append($"Best chromosome: {BestChromosome}");

        return sb.ToString();
    }
}
