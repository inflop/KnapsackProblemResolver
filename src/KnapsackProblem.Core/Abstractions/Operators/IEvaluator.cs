namespace KnapsackProblem.Core.Abstractions.Operators;

/// <summary>
/// Interfejs opisujący klasę wyliczającą wartość przystosowania chromosomu.
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="genes"></param>
    /// <returns></returns>
    Fitness Evaluate(Gene[] genes);
}
