using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Host.WebApp;

public class Parameters : IParameters
{
    public Size KnapsackSize { get; set; } = 250;

    public Size PopulationSize { get; set; } = 500;

    public string? InputFile { get; set; }

    public int? IterationsLimit { get; set; } = 300;

    public int? IterationsLimitWithoutImprovement { get; set; } = 30;

    public Rate MutationRate { get; set; } = 0.1d;

    public Rate CrossoverRate { get; set; } = 0.8d;

    public SelectionType SelectionType { get; set; } = SelectionType.Roulette;

    public CrossoverType CrossoverType { get; set; } = CrossoverType.OnePoint;

    private IEnumerable<Item> _items = Enumerable.Empty<Item>();
    public IEnumerable<Item> Items
    {
        get
        {
            if (InputFile is null)
                return Enumerable.Empty<Item>();

            _items = File.ReadAllLines(InputFile!)
                .Skip(1)
                .Select(line =>
                {
                    string[] columns = line.Split(',');
                    _ = int.TryParse(columns[0], out int value);
                    _ = int.TryParse(columns[1], out int weight);

                    return new Item(value, weight);
                });

            return _items;
        }

        set
        {
            _items = value;
        }
    }

    public EvaluatorParameters EvaluatorParameters
        => new EvaluatorParameters(Items, KnapsackSize);

    public CrossoverParameters CrossoverParameters
        => new CrossoverParameters(CrossoverType, CrossoverRate);

    public IterationParameters IterationParameters
        => new IterationParameters(IterationsLimit, IterationsLimitWithoutImprovement);

    public Size ChromosomeSize
        => Items.Count();
}
