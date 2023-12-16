namespace KnapsackProblem.Core.Parameters;

/// <summary>
/// Rekord reprezentujący parametry kontrolera iteracji algorytmu.
/// </summary>
/// <param name="TotalIterationsLimit">Ogólny limit iteracji</param>
/// <param name="IterationsLimitWithoutImprovement">Limit iteracji bez poprawy wyniku.</param>
public record IterationParameters(int? TotalIterationsLimit, int? IterationsLimitWithoutImprovement);
