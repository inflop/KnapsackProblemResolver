using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Core.Abstractions.Factories;

/// <summary>
/// Interfejs reprezentujący fabrykę operatora mutacji.
/// </summary>
public interface IMutatorFactory
{
    /// <summary>
    /// Tworzy nową instancję operatora mutacji uwzględniając
    /// współczynnik mutacji przekazany jako parametr.
    /// </summary>
    /// <param name="mutationRate">Współczynnik mutacji.</param>
    /// <returns>Zwraca nową instancję operatora mutacji.</returns>
    IMutator Create(Rate mutationRate);
}
