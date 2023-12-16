using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;

namespace KnapsackProblem.Application.Operators.Selection;

/// <summary>
/// W tym podejściu dla każdego osobnika określane jest prawdopodobieństwo jego wyboru,
/// które obliczane jest jako iloraz wartości funkcji przystosowania danego osobnika
/// i sumy wartości przystosowania wszystkich osobników w populacji.
/// Prawdopodobieństwo wylosowania osobnika jest zatem wprost proporcjonalne
/// do jego wartości funkcji oceny, stąd nazwa reprodukcja proporcjonalna.
/// Zwana jest także reprodukcją ruletkową, gdyż można ją zobrazować w formie koła ruletki,
/// w którym każdemu osobnikowi przypisuje się pole powierzchni proporcjonalne do jego przystosowania.
/// Przy takim podejściu należy pamiętać, aby funkcja oceny przyjmowała zawsze wartości dodatnie.
/// Metoda jest czuła na dodawanie do funkcji oceny stałej wartości,
/// przez co pozwala na sterowanie i korygowanie nacisku selektywnego
/// (poprzez odjęcie bądź dodanie stałej wartości do funkcji oceny).
/// Należy także zauważyć, że reprodukcja ta jest nieodporna na występowanie super-osobników
/// (czyli pojedynczych osobników o wyróżniającej się, odbiegającej od reszty, większej wartości funkcji oceny).
/// Selekcja ruletkowa eksponuje duże różnice pomiędzy osobnikami,
/// a niebezpieczeństwo z nią związane to utrata różnorodności w populacji.
/// </summary>
public class RouletteSelector : ISelector
{
    private readonly Random _random = new();

    public Chromosome Select(Population population)
    {
        int totalValue = population.Chromosomes.Sum(chromosome => chromosome.Fitness.Value);
        double randomValue = _random.NextDouble() * totalValue;
        double sumValue = 0;

        foreach (var chromosome in population.Chromosomes)
        {
            sumValue += chromosome.Fitness.Value;
            if (sumValue > randomValue)
                return chromosome.Clone();
        }

        return population.BestChromosome!.Clone();
    }
}
