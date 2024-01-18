using System.Text;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Host.GtkApp;

public class Parameters : IParameters
{
    public int KnapsackSize { get; set; } = 250;

    public int PopulationSize { get; set; } = 300;

    public string? InputFile { get; set; } = "./input.csv";

    public int? IterationsLimit { get; set; }

    public int? IterationsLimitWithoutImprovement { get; set; } = 30;

    public double MutationRate { get; set; } = 0.01d;

    public double CrossoverRate { get; set; } = 0.9d;

    public SelectionType SelectionType { get; set; } = SelectionType.Roulette;

    public CrossoverType CrossoverType { get; set; } = CrossoverType.OnePoint;

    private IEnumerable<Item> _items = Enumerable.Empty<Item>();
    public IEnumerable<Item> Items
    {
        get
        {
            if (InputFile is null)
                return [];

            _items = File.ReadAllLines(InputFile!)
                .Skip(1)
                .Select(line =>
                {
                    string[] columns = line.Split(',');
                    _ = int.TryParse(columns[0], out int value);
                    _ = int.TryParse(columns[1], out int weight);

                    return new Item(value, weight);
                });

            return _items.ToList();
        }

        set => _items = value;
    }

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

        if (IterationsLimit.HasValue)
            sb.AppendLine($"Iterations limit: {IterationsLimit}");

        if (IterationsLimitWithoutImprovement.HasValue)
            sb.AppendLine($"Iterations limit without improvement: {IterationsLimitWithoutImprovement}");

        sb.AppendLine($"Mutation rate: {MutationRate}");
        sb.AppendLine($"Crossover rate: {CrossoverRate}");
        sb.AppendLine($"Selection type: {SelectionType}");
        sb.AppendLine($"Crossover type: {CrossoverType}");
        sb.AppendLine($"Input file: {InputFile}");
        //sb.Append($"Items: {JsonSerializer.Serialize(Items, new JsonSerializerOptions() { WriteIndented = false })}");
        return sb.ToString();
    }
}
