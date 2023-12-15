namespace KnapsackProblem.Core;

/// <summary>
/// Rekord reprezentujacy przedmiot plecaka.
/// </summary>
/// <param name="Value">Wartość przedmiotu.</param>
/// <param name="Weight">Waga przedmiotu.</param>
public record struct Item(int Value, int Weight);
