namespace KnapsackProblem.Core;

/// <summary>
/// Struktura typu ValueObject opisująca pojedynczy gen będący wartością bitową.
/// </summary>
/// <param name="Value">Wartość genu</param>
public readonly record struct Gene(bool Value)
{
    /// <summary>
    /// Metoda tworząca gen o losowej wartości bitowej.
    /// </summary>
    public static Gene CreateRandom()
        => new(new Random().Next(100) % 2 == 0);

    /// <summary>
    /// Operacja mutowania.
    /// Zwraca gen z wartością przeciwną
    /// do wartości genu bieżącego.
    /// </summary>
    public Gene Mutate()
        => !this;

    public override string ToString()
        => $"{(int)this}";

    public static implicit operator int(Gene value)
        => value.Value ? 1 : 0;

    public static implicit operator Gene(int value)
        => new(value == 1);

    public static implicit operator bool(Gene value)
        => value.Value;

    public static implicit operator Gene(bool value)
        => new(value);

    public bool Equals(Gene other)
        => other.Value.Equals(Value);

    public static Gene operator !(Gene a)
        => !a.Value;

    public override int GetHashCode()
        => Value.GetHashCode();
}
