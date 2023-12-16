namespace KnapsackProblem.Core.Enums;

/// <summary>
/// Obsługiwane rodzaje krzyżowania.
/// </summary>
public enum CrossoverType
{
    /// <summary>
    /// Jednopunktowe.
    /// </summary>
    /// <remarks>
    /// W tej metodzie losowo wybiera się pojedynczy punkt podziału na chromosomach rodziców.
    /// Geny po jednej stronie punktu są wymieniane między dwoma rodzicami, tworząc dwa nowe chromosomy.
    /// </remarks>
    OnePoint,

    /// <summary>
    /// Dwupunktowe.
    /// </summary>
    /// <remarks>
    /// W tej metodzie losowo wybiera się dwa punkty podziału na chromosomach rodziców.
    /// Geny między punktami podziału są wymieniane między rodzicami.
    /// </remarks>
    TwoPoint,

    /// <summary>
    /// Jednorodne.
    /// </summary>
    /// <remarks>
    /// W tej metodzie każdy gen jest niezależnie wybierany od jednego z rodziców z określonym prawdopodobieństwem.
    /// To pozwala na bardziej równomierną wymianę informacji genetycznej.
    /// </remarks>
    Uniform
}
