using KnapsackProblem.Core.Domain;

namespace KnapsackProblem.Core.Abstractions;

/// <summary>
/// Interfejs reprezentujący klasę dostawcy najlepszego chromosomu.
/// </summary>
public interface IBestChromosomeProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="chromosome"></param>
    /// <param name="iteration"></param>
    /// <returns></returns>
    bool SetBetter(Chromosome chromosome, int iteration);
    
    /// <summary>
    /// 
    /// </summary>
    BestChromosome? BestChromosome { get; }
    
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<BestChromosome> History { get; }
    
    /// <summary>
    /// 
    /// </summary>
    void Reset();
}
