using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Core.Abstractions.Factories;

/// <summary>
/// Interfejs reprezentujący fabrykę operatora krzyżowania.
/// </summary>
public interface ICrossoverFactory
{
    /// <summary>
    /// Tworzy nową instancję operatora krzyżowania w oparciu
    /// o wartości parametrów przekazanych do metody.
    /// </summary>
    /// <param name="parameters">Parametry krzyżowania.</param>
    /// <returns>Zwraca nową instancję operatora krzyżowania.</returns>
    ICrossover Create(CrossoverParameters parameters);
}
