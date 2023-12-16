using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Application.Operators;

/// <summary>
/// Klasa reprezentująca funkcję przystosowania chromosomu.
/// Wylicza wartość przystosowania dla przekazanego zbioru genów osobnika.
/// </summary>
public class Evaluator(EvaluatorParameters parameters) : IEvaluator
{
    /// <summary>
    /// Zwraca rezultat operacji generowania oceny dla przekazanego zbioru genów.
    /// Zwraca wartość przystosowania, czyli sumę wartości wszystkich elementów oraz sumę ich wag.
    /// </summary>
    /// <param name="genes">Zbiór genów przekazany do oceny.</param>
    /// <returns></returns>
    public Fitness Evaluate(Gene[] genes)
    {
        var weight = parameters.Items.Select((item, index) => genes[index] * item.Weight).Sum();
        var calculatedValue = parameters.Items.Select((item, index) => genes[index] * item.Value).Sum();
        var value = weight > parameters.KnapsackSize ? 0 : calculatedValue;
        return new Fitness(value, weight);
    }
}
