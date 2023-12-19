using System.Text;
using System.Text.Json;
using CommandLine;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Host.Console;

public class Parameters : IParameters
{
    /// <summary>
    /// Rozmiar plecaka.
    /// </summary>
    [Option(shortName: 'k', longName: "knapsack-size", HelpText = "The size of the knapsack", Default = 250)]
    public int KnapsackSize { get; set; } = 250;

    /// <summary>
    /// Rozmiar populacji.
    /// </summary>
    [Option(shortName: 'p', longName: "population-size", HelpText = "The size of the population", Default = 300)]
    public int PopulationSize { get; set; } = 300;

    /// <summary>
    /// Ścieżka do pliku wejściowego zawierającego dane wartości i wag przedmiotów.
    /// </summary>
    [Option(shortName: 'i', longName: "input-items-file", HelpText = "The input csv file contains items with values and weights", Default = "./input.csv")]
    public string? InputFile { get; set; } = "./input.csv";

    /// <summary>
    /// Ilość iteracji algorytmu.
    /// </summary>
    [Option(shortName: 'l', longName: "iterations-limit", HelpText = "The iterations count of the genetic algorithm.If 'null' then 'unlimited'", Default = null)]
    public int? IterationsLimit { get; set; } = null;

    /// <summary>
    /// Limit iteracji algorytmu bez poprawy wyniku.
    /// </summary>
    [Option(shortName: 'n', longName: "no-improvement-iterations-limit", HelpText = "The iterations limit without improvement", Default = 30)]
    public int? IterationsLimitWithoutImprovement { get; set; } = 30;

    /// <summary>
    /// Współczynnik procentowy mutacji osobnika.
    /// </summary>
    [Option(shortName: 'm', longName: "mutation-rate", HelpText = "The mutation rate of the chromosome. The value between 0.01 and 0.99.", Default = .01d)]
    public double MutationRate { get; set; } = .01d;

    /// <summary>
    /// Współczynnik procentowy krzyżowania populacji.
    /// </summary>
    [Option(shortName: 'c', longName: "crossover-rate", HelpText = "The crossover rate of a population. The value between 0.01 and 0.99.", Default = .9d)]
    public double CrossoverRate { get; set; } = .9d;

    /// <summary>
    /// Zastosowany rodzaj selekcji osobników.
    /// </summary>
    [Option(shortName: 's', longName: "selection-type", HelpText = "The selection type.", Default = SelectionType.Roulette)]
    public SelectionType SelectionType { get; set; }

    /// <summary>
    /// Zastosowany rodzaj krzyżowania osobników.
    /// </summary>
    [Option(shortName: 'o', longName: "crossover-type", HelpText = "The crossover type.", Default = CrossoverType.OnePoint)]
    public CrossoverType CrossoverType { get; set; } = CrossoverType.OnePoint;

    /// <summary>
    /// Lista przedmiotów.
    /// </summary>
    public IEnumerable<Item> Items
    {
        get
        {
            return File.ReadAllLines(InputFile!)
            .Skip(1)
            .Select(line =>
            {
                string[] columns = line.Split(',');
                _ = int.TryParse(columns[0], out int value);
                _ = int.TryParse(columns[1], out int weight);

                return new Item(value, weight);
            });
        }
    }

    /// <summary>
    /// Rozmiar chromosomu na podstawie ilości przedmiotów w zestawie.
    /// </summary>
    /// <returns></returns>
    public int ChromosomeSize
        => Items.Count();

    public EvaluatorParameters EvaluatorParameters
        => new EvaluatorParameters(Items, KnapsackSize);

    public CrossoverParameters CrossoverParameters
        => new CrossoverParameters(CrossoverType, CrossoverRate);

    public IterationParameters IterationParameters
        => new IterationParameters(IterationsLimit, IterationsLimitWithoutImprovement);

    /// <summary>
    /// Zwraca listę parametrów jako obiekt typu JSON w postaci łańcucha znaków.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Knapsack size: {KnapsackSize}");
        sb.AppendLine($"Population size: {PopulationSize}");
        sb.AppendLine($"Iterations limit: {IterationsLimit}");
        sb.AppendLine($"Iterations limit without improvement: {IterationsLimitWithoutImprovement}");
        sb.AppendLine($"Mutation rate: {MutationRate}");
        sb.AppendLine($"Crossover rate: {CrossoverRate}");
        sb.AppendLine($"Selection type: {SelectionType}");
        sb.AppendLine($"Crossover type: {CrossoverType}");
        sb.AppendLine($"Input file: {InputFile}");
        sb.Append($"Items: {JsonSerializer.Serialize(Items, new JsonSerializerOptions() { WriteIndented = false })}");
        return sb.ToString();
    }
}
