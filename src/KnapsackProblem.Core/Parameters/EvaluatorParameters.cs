using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Core.Parameters;

/// <summary>
/// Parametry wejściowe metody wyliczającej wartość przystosowania.
/// </summary>
/// <param name="Items">Lista przedmiotów.</param>
/// <param name="KnapsackSize">Rozmiar plecaka.</param>
public record class EvaluatorParameters(IEnumerable<Item> Items, Size KnapsackSize);
