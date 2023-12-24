using KnapsackProblem.Core;
using KnapsackProblem.Core.ValueObjects;

namespace KnapsackProblem.Host.Console;

public static class Extensions
{
    public static void Validate(this Parameters parameters)
    {
        if (!File.Exists(parameters.InputFile))
            throw new FileNotFoundException(Path.GetFullPath(parameters.InputFile!));

        if (parameters.MutationRate < Rate.Min || parameters.MutationRate > Rate.Max)
            throw new ArgumentOutOfRangeException($"The value for {nameof(parameters.MutationRate)} must be between {Rate.Min} and {Rate.Max}.");

        if (parameters.CrossoverRate < Rate.Min || parameters.CrossoverRate > Rate.Max)
            throw new ArgumentOutOfRangeException($"The value for {nameof(parameters.CrossoverRate)} must be between {Rate.Min} and {Rate.Max}.");

        if (parameters.KnapsackSize < Size.Min || parameters.KnapsackSize > Size.Max)
            throw new ArgumentOutOfRangeException($"The value for {nameof(parameters.KnapsackSize)} must be between {Size.Min} and {Size.Max}.");

        if (parameters.PopulationSize < Size.Min || parameters.PopulationSize > Size.Max)
            throw new ArgumentOutOfRangeException($"The value for {nameof(parameters.PopulationSize)} must be between {Size.Min} and {Size.Max}.");
    }
}