using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Domain;

namespace KnapsackProblem.Application.Operators.Selection;

/// <summary>
/// W tym podejściu wybór osobników, które zostaną faktycznymi rodzicami odbywa się etapowo.
/// Z populacji losowane są zbiory n-osobników, które biorą udział w turnieju.
/// Losowanie to może odbywać się w dwóch wariantach: ze zwracaniem lub bez.
/// Osobnik o najlepszym przystosowaniu wygrywa zawody i zostaje dołączony do grupy osobników wybranych w reprodukcji.
/// Losowanie podzbiorów n-osobników i turnieje odbywają się aż do momentu zapełnienia populacji,
/// która weźmie udział w dalszym przetwarzaniu (aż do wyboru odpowiedniej liczby rodziców w procesie reprodukcji).
/// Wartość n jest wielkością turnieju i steruje intensywnością selektywnego nacisku (im mniejsze n tym mniejszy nacisk).
/// Najczęściej przyjmuje się wielkość turnieju równą 2. Potencjalną zaletą selekcji turniejowej,
/// która wyróżnia ją od pozostałych jest fakt, że potrzebuje ona jedynie określenia wyboru najlepszego osobnika
/// z n-biorących udział w turnieju. Dlatego może być z powodzeniem stosowana w przypadkach,
/// gdzie nie ma formalnej obiektywnej metody oceny osobników. 
/// </summary>
public class TournamentSelector : ISelector
{
    private readonly int _tournamentSize = 2;
    private readonly Random _random = new();

    public Chromosome Select(Population population)
    {
        var chromosomes = population.Chromosomes.ToArray();
        var selected = new List<Chromosome>();
        for (int i = 0; i < _tournamentSize; i++)
        {
            int randomIndex = _random.Next(population.Size);
            var chromosome = chromosomes[randomIndex];
            selected.Add(chromosome);
        }

        return selected.MaxBy(i => i.Fitness.Value)!.Clone();
    }
}
