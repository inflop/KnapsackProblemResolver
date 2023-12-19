using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Core.Abstractions;

/// <summary>
/// Interfejs reprezentujący parametry wejściowe algorytmu.
/// </summary>
public interface IParameters
{
    /// <summary>
    /// Rozmiar plecaka.
    /// </summary>
    int KnapsackSize { get; }

    /// <summary>
    /// Rozmiar populacji.
    /// </summary>
    int PopulationSize { get; }

    /// <summary>
    /// Ścieżka do pliku wejściowego zawierającego dane wartości i wag przedmiotów.
    /// </summary>
    string? InputFile { get; }

    /// <summary>
    /// Ilość iteracji algorytmu.
    /// </summary>
    int? IterationsLimit { get; }

    /// <summary>
    /// Limit iteracji algorytmu bez poprawy wyniku.
    /// </summary>
    int? IterationsLimitWithoutImprovement { get; }

    /// <summary>
    /// Współczynnik procentowy mutacji osobnika.
    /// </summary>
    double MutationRate { get; }

    /// <summary>
    /// Współczynnik procentowy krzyżowania populacji.
    /// </summary>
    double CrossoverRate { get; }

    /// <summary>
    /// Zastosowany rodzaj selekcji osobników.
    /// </summary>
    SelectionType SelectionType { get; }

    /// <summary>
    /// Zastosowany rodzaj krzyżowania osobników.
    /// </summary>
    CrossoverType CrossoverType { get; }

    /// <summary>
    /// Lista przedmiotów.
    /// </summary>
    IEnumerable<Item> Items { get; }

    /// <summary>
    /// Rozmiar chromosomu na podstawie ilości przedmiotów w zestawie.
    /// </summary>
    int ChromosomeSize { get; }

    /// <summary>
    /// Parametry wejściowe metody wyliczającej wartość przystosowania.
    /// </summary>
    EvaluatorParameters EvaluatorParameters { get; }

    /// <summary>
    /// Parametry krzyżowania.
    /// </summary>
    CrossoverParameters CrossoverParameters { get; }

    /// <summary>
    /// Parametry kontrolera iteracji algorytmu.
    /// </summary>
    IterationParameters IterationParameters { get; }
}
