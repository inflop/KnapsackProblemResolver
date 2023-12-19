namespace KnapsackProblem.Core.Abstractions;

/// <summary>
/// Interfejs reprezentujący klasę obiektu rozwiązującego problem plecakowy. 
/// </summary>
public interface IProblemResolver
{
    /// <summary>
    /// Główna metoda wejściowa, rozwiązująca problem plecakowy,
    /// w oparciu o wartości parametrów przekazane do metody
    /// </summary>
    /// <param name="parameters">
    /// Wszystkie parametry niezbędne do rozwiązania problemu.
    /// </param>
    /// <returns>
    /// Obiekt będący reprezentacją rezultatu rozwiązania problemu.
    /// </returns>
    ResolveResult Resolve(IParameters parameters);
}
