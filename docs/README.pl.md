# Sztuczna Inteligencja - Projekt

## Zastosowanie algorytmów genetycznych w problemie plecakowym

### 1. Opis projektu

Celem projektu jest zaimplementowanie algorytmu genetycznego (AG) do rozwiązania problemu plecakowego. Problem plecakowy polega na wyborze określonych przedmiotów w taki sposób, aby ich wartość była jak największa, ale suma ich wag nie przekraczała określonej pojemności plecaka.

### 2. Zadania projektowe

#### (a) Implementacja struktury chromosomu

Zdefiniuj strukturę chromosomu reprezentującego rozwiązanie problemu plecakowego.

#### (b) Tworzenie populacji

Stwórz losową populację chromosomów reprezentujących różne zestawy przedmiotów w plecaku.

#### (c) Funkcja przystosowania

Zaimplementuj funkcję przystosowania, która ocenia każde rozwiązanie pod kątem jego wartości i zgodności z ograniczeniami plecaka (suma wag).

#### (d) Selekcja

Wybierz rodziców do krzyżowania na podstawie funkcji przystosowania. Możesz użyć metod selekcji takich jak ruletka, ranking, lub turniej.

#### (e) Krzyżowanie

Wykonaj operację krzyżowania na parach rodziców, aby uzyskać potomstwo. Możesz zaimplementować różne metody krzyżowania.

#### (f) Mutacja

Wprowadź losowe zmiany w potomstwie, aby zachować różnorodność w populacji.

#### (g) Algorytm genetyczny

Zaimplementuj główną pętlę algorytmu genetycznego, w której powtarzasz operacje selekcji, krzyżowania i mutacji przez pewną liczbę pokoleń.

#### (h) Wynik

Zapisz najlepsze rozwiązanie znalezione przez algorytm genetyczny.

#### (i) Dobór narzędzi i języka programowania

Wybierz narzędzia i język programowania do implementacji algorytmu genetycznego. Możesz wybrać dowolny język programowania, ale nie można korzystać z gotowych bibliotek do rozwiązywania problemu plecakowego.

#### (j) Sprawozdanie

Sporządź sprawozdanie z przebiegu projektu. Krótko opisz napotkane problemy i ich rozwiązania przy poszczególnych etapach AG.

### 3. Testowy zestaw danych

Do testowania algorytmu genetycznego w rozwiązywaniu problemu plecakowego można użyć przykładowego zestawu danych, który zawiera wartości i wagi przedmiotów oraz pojemność plecaka. Oto przykładowy zestaw danych:

- Wartości przedmiotów: [60, 100, 120, 50, 60, 30, 70, 110, 130, 60, 90, 40, 80, 90, 110, 120, 50, 100, 30, 70]
- Wagi przedmiotów: [10, 20, 30, 40, 50, 10, 60, 70, 80, 20, 30, 15, 25, 35, 40, 45, 10, 30, 15, 25]
- Pojemność plecaka: 250

### 4. Forma przekazania ćwiczenia

Do oceny wysyłamy plik nr_indeksu_imię_nazwisko.zip, np. 123456_Jan_Kowalski.zip. Plik ten musi zawierać sprawozdanie z projektu w formacie PDF oraz plik z kodem źródłowym.

> _(zawartość typu markdown została wygenerowana i przetłumaczona przez ChatGPT ze źródłowego [pliku PDF](./projekt.pdf))_
