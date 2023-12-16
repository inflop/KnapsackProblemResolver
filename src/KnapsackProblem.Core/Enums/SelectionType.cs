namespace KnapsackProblem.Core.Enums;

/// <summary>
/// Obsługiwane metody selekcji.
/// </summary>
public enum SelectionType
{
    /// <summary>
    /// Metoda koła ruletki.
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
    /// a niebezpieczeństwo z nią związane to utrata różnorodności w populacji./// 
    /// </summary>
    Roulette = 0,

    /// <summary>
    /// Metoda rankingowa.
    /// W tym podejściu każdy z osobników otrzymuje rangę,
    /// która jest wyznaczana na podstawie wartości funkcji oceny.
    /// Najprostszym sposobem nadania rang jest po prostu posortowanie osobników
    /// w kolejności niemalejącej od największej do najniższej wartości przystosowania.
    /// Rangi są kolejnymi numerami osobników w takim uszeregowaniu.
    /// W przypadku wystąpienia osobników o tej samej wartości oceny możemy postąpić dwojako:
    /// - albo nadać kolejny numer zgodnie z uszeregowaniem – wtedy osobniki otrzymają inne rangi,
    /// - albo nadać im tą samą rangę.
    /// Rangi są zatem liczbami całkowitymi nieujemnymi (rangi nadajemy od 0).
    /// Ranga nadana osobnikowi wykorzystywana jest w funkcji,
    /// która definiuje jakie prawdopodobieństwo wylosowania ma zostać mu nadane.
    /// Funkcja ta jest najczęściej liniowa.
    /// </summary>
    Rank = 1,

    /// <summary>
    /// Metoda turniejowa.
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
    Tournament = 2
}
