namespace KnapsackProblem.Core.Abstractions.Operators;

/// <summary>
/// Interfejs opisujący klasę odpowiedzialną za krzyżowanie chromosomów.
/// </summary>
public interface ICrossover
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent1"></param>
    /// <param name="parent2"></param>
    /// <returns></returns>
    IEnumerable<Chromosome> Cross(Chromosome parent1, Chromosome parent2);
}
