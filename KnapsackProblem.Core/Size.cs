namespace KnapsackProblem.Core;

/// <summary>
/// Struktura typu ValueObject reprezentująca
/// rozmiar jako liczbę całkowitą z zakresu
/// od 1 do 1 000 000.
/// </summary>
public readonly record struct Size
{
    private readonly int _value = 0;

    public Size(int value)
    {
        if (value > Max || value < Min)
            throw new ArgumentOutOfRangeException($"The size value '{value}' must be between '{Min}' and '{Max}'.");

        _value = value;
    }
    
    /// <summary>
    /// Wartość rozmiaru.
    /// </summary>
    public int Value
        => _value;

    public static int Min
        => 1;

    public static int Max
        => 1_000_000;

    public static implicit operator int(Size value)
        => value.Value;

    public static implicit operator Size(int value)
        => new(value);

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => $"{Value}";
}
