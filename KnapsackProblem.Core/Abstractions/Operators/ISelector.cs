namespace KnapsackProblem.Core.Abstractions.Operators;

/// <summary>
/// Interfejs opisujący klasę odpowiedzialną za selekcję chromosomu.
/// </summary>
public interface ISelector
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="population">Populacja poddawana selekcji</param>
    /// <returns></returns>
    Chromosome Select(Population population);
}
