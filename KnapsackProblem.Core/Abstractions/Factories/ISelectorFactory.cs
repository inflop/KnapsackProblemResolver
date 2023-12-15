using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Enums;

namespace KnapsackProblem.Core.Abstractions.Factories;

/// <summary>
/// Interfejs reprezentujący fabrykę operatora selekcji.
/// </summary>
public interface ISelectorFactory
{
    /// <summary>
    /// Tworzy nową instancję operatora selekcji w oparciu
    /// o typ selekcji przekazany do metody.
    /// </summary>
    /// <param name="type">Typ selekcji, dla któ©ego ma zostać utworzony operator.</param>
    /// <returns>Zwraca nową instancję operatora selekcji.</returns>
    ISelector Create(SelectionType type);
}
