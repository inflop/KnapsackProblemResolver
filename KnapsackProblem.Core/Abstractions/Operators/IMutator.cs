namespace KnapsackProblem.Core.Abstractions.Operators;

/// <summary>
/// Interfejs opisujący klasę odpowiedzialną za mutację genów.
/// </summary>
public interface IMutator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="genes"></param>
    /// <returns></returns>
    Gene[] Mutate(Gene[] genes);
}
