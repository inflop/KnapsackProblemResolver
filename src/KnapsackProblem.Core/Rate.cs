namespace KnapsackProblem.Core;

/// <summary>
/// Struktura typu ValueObject reprezentująca
/// współczynnik/wartość procentową w zakresie
/// od 0.01 do 0.99.
/// </summary>
public readonly record struct Rate
{
    private readonly double _value = 0;

    public Rate(double value)
    {
        if (value > Max || value < Min)
            throw new ArgumentOutOfRangeException($"The rate value '{value}' must be between '{Min}' and '{Max}'.");

        _value = value;
    }
    
    /// <summary>
    /// Wartość współczynnika.
    /// </summary>
    public double Value
        => _value;

    public static double Min
        => .01;

    public static double Max
        => .99;

    public static implicit operator double(Rate value)
        => value.Value;

    public static implicit operator Rate(double value)
        => new(value);

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => $"{Value}";
}
