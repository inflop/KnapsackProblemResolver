using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Core.Abstractions;

/// <summary>
/// Interfejs reprezentujący kontroler iteracji,
/// czyli wyjścia z pętli algorytmu.
/// </summary>
public interface IIterationController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    void Initialize(IterationParameters parameters);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentIteration"></param>
    /// <returns></returns>
    bool Terminate(int currentIteration);
}
