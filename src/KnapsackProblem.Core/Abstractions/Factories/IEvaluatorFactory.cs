using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Core.Abstractions.Factories;

/// <summary>
/// Interfejs reprezentujący fabrykę klasy funkcji przystosowania.
/// </summary>
public interface IEvaluatorFactory
{
    /// <summary>
    /// Tworzy nową instancję klasy funkcji przystosowania w oparciu
    /// o wartości parametrów przekazanych do metody.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>Zwraca nową instancję klasy funkcji przystosowania.</returns>
    IEvaluator Create(EvaluatorParameters parameters);
}
