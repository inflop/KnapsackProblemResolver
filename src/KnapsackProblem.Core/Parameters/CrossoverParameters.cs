using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Core.Parameters;

/// <summary>
/// Rekord reprezentujący parametry krzyżowania.
/// </summary>
/// <param name="Type">Typ krzyżowania.</param>
/// <param name="Rate">Współczynnik krzyżowania.</param>
public record CrossoverParameters(CrossoverType Type, Rate Rate);
