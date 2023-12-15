using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Application;

/// <summary>
/// Klasa odpowiedzialna za przerwanie pętli algorytmu,
/// na podstawie zdefiniowanych kryteriów.
/// </summary>
public class IterationController(IBestChromosomeProvider bestChromosomeProvider) : IIterationController
{
    private BestChromosome? _lastBestChromosome = null;
    private IterationParameters? _parameters;

    public void Initialize(IterationParameters parameters)
    {
        _parameters = parameters;
        _lastBestChromosome = null;
    }

    public bool Terminate(int currentIteration)
    {
        if (_parameters is null)
            throw new InvalidOperationException($"The controller has not been initialized. Run the '{nameof(Initialize)}' method first.");

        var currentBestChromosome = bestChromosomeProvider.BestChromosome;

        if (currentBestChromosome is null)
            return false;

        bool reachedIterationLimit = ReachedIterationLimit(currentIteration);
        if (reachedIterationLimit)
            return true;

        bool isBetter = _lastBestChromosome is null || currentBestChromosome?.Fitness.Value > _lastBestChromosome?.Fitness.Value;
        if (isBetter)
        {
            _lastBestChromosome = currentBestChromosome;
            return false;
        }

        bool reachedIterationLimitWithoutImprovement = _parameters.IterationsLimitWithoutImprovement.HasValue &&
                                                        currentIteration - _lastBestChromosome?.Iteration >= _parameters.IterationsLimitWithoutImprovement;

        return reachedIterationLimitWithoutImprovement;
    }

    private bool ReachedIterationLimit(int currentIteration)
    {
        if (!_parameters!.TotalIterationsLimit.HasValue)
            return false;

        return currentIteration >= _parameters.TotalIterationsLimit;
    }
}
