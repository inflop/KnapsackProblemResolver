using System.Text;

namespace KnapsackProblem.Core.Domain;

/// <summary>
/// Rekord reprezentujący wartość przystosowania chromosomu.
/// </summary>
/// <param name="Value">Wartość przystosowania.</param>
/// <param name="Weight">Suma wag przedmiotów</param>
public readonly record struct Fitness(int Value, int Weight)
{
    /// <summary>
    /// Zwraca domyślna wartość przystosowania (0, 0).
    /// </summary>
    public static Fitness Default
        => new(0, 0);

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Fitness value: {Value}");
        sb.Append($"Fitness weight: {Weight}");
        return sb.ToString();
    }
}
