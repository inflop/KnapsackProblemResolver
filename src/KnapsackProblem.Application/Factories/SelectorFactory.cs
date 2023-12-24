using KnapsackProblem.Application.Operators.Selection;
using KnapsackProblem.Core.Abstractions.Factories;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Enums;

namespace KnapsackProblem.Application.Factories;

public class SelectorFactory : ISelectorFactory
{
    public ISelector Create(SelectionType type)
        => _selectors[type].Invoke();

    private readonly Dictionary<SelectionType, Func<ISelector>> _selectors = new()
    {
        [SelectionType.Roulette] = () => new RouletteSelector(),
        [SelectionType.Tournament] = () => new TournamentSelector(),
        [SelectionType.Rank] = () => new RankSelector()
    };
}
