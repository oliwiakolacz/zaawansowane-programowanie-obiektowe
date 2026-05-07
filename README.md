# System rezerwacji escape roomów

**Autor:** Oliwia Kołacz  
**Indeks:** 83099  
**Przedmiot:** Zaawansowane programowanie obiektowe  
**Framework:** .NET 10 / C#

## Opis

System rezerwacji escape roomów.
Konsolowa aplikacja w C# (.NET 10) demonstrująca zaawansowane programowanie obiektowe.

## Uruchomienie

```bash
dotnet run
```

## Programowanie obiektowe

| # | Co? | Gdzie i jak? |
|---|---|---|
| 1 | Klasy | `Klient.cs`, `Rezerwacja.cs`, `EscapeRoom.cs` (abstrakcyjna), `Repozytorium.cs`, `KlasycznyPokoj.cs`, `PokojVR.cs`, `KalkulatorCen.cs` (statyczna)|
| 2 | Konstruktory | W klasie `Rezerwacja.cs` są dwa konstruktory, jeden wywołuje drugi przez `: this(...)`. |
|   |              | W klasie abstrakcyjnej `EscapeRoom.cs` konstruktor jest `protected`. Nie jest to konieczne, bo nie da się utworzyć obiektu klasy abstrakcyjnej, ale zgodne ze standardami.|
|   |              | W podklasach `KlasycznyPokoj.cs` i `PokojVR.cs` jest konstruktor wywołujący konstruktor klasy nadrzędnej abstrakcyjnej `EscapeRoom.cs` przez `: base(...)`. |
|   |              | W klasie  `Klient.cs` jest jeden zdefiniowany konstruktor `public`.|
|   |              | W klasie  `Repozytorium.cs` jest jeden konstruktor domyślny (niezdefiniowany) bezargumentowy.|
| 3 | Właściwości / Indeksatory | Auto-properties są uzywane licznie w klasach. Zazwyczaj gettery są publiczne, a settery prywatne. Przykład: `public string Email { get; private set; }` |
|   |                            | Indeksator `public T this[int indeks] => _elementy[indeks];` jest uzyty w klasie  w `Repozytorium.cs`. Po utworzeniu obiektu klasy repozytorium `var repo = new Repozytorium<Rezerwacja>();` pozwala on na odczytywanie kolekcji, liscie repozytorium jak po tablicy `repo[0]` np. `var pierwszyRepo = repo[0]`|
| 4 | Statyczne | Klasa statyczna `KalkulatorCen.cs` ze statycznymi metodami `KalkulatorCen.ZeZnizka(...)`, `KalkulatorCen.CenaWeekendowa(...)`.|
|   |            | Pole statyczne `Rezerwacja.LiczbaWszystkich` do zliczania rezerwacji w klasie `Rezerwacja.cs`.|
| 5 | Dziedziczenie | Obydwie klasy `KlasycznyPokoj.cs`, `PokojVR.cs` dziedziczą po klasie abstrakcyjnej `EscapeRoom.cs`. |
| 6 | Polimorfizm | W projekcie wykorzystano wiele miechanizmów opartych na polimorfizmie m.in metodę wirtualną `virtual decimal Cena()` w klasie abstrakcyjnej `EscapeRoom.cs`, którą nadpisujemy `override` w klasach pochodnych. Uzyto rowniez interfejsu, jak i przeciazania operatorow.|
| 7 | Interfejsy / Abstrakcja | Interfejs `IRezerwacja.cs`, którego implementuje abstrakcyjna klasa `EscapeRoom.cs`.|
|   |                         | Abstrakcyjna klasa `EscapeRoom.cs`, która posiada m.in. wirtualna metode `public virtual decimal Cena() => 200m;` z wartością domyślną. Przez uzycie modyfikatora `virtual` klasy dziedziczące mogą nadpisać tą metodę, ale nie muszą. |
| 8 | Typy ogólne / Kolekcje | Klasa `Repozytorium.cs` jest generyczna (`public class Repozytorium<T> where T : class`) tj. potrzebuje zdefiniowania typu przy powołaniu jej obiektów. Zapis `where T : class` ogranicza mozliwe typy do klas, interfejsów, delegatów i typów referencyjnych. Przykład uzycia: `var repo = new Repozytorium<Rezerwacja>();` |
|   |                        | Klasa `Repozytorium.cs` posiada kolekcję, listę `List<T>`.|
| 9 | Delegacje / Zdarzenia | Zdarzenia `public event Action<T>? Dodano;` oraz `public event Action<T>? Usunieto;` uzyto w klasie `Repozytorium.cs`. |
|    |                      | Uzyto delegacji `Func<T, bool>` w metodzie `Usun` w klasie `Repozytorium.cs`. |
| 10 | Przeciążanie operatorów | W klasie `Rezerwacja.cs` przeciązono operatory `==` i `!=`. Pozwala to na porównanie obiektów klasy `Rezerwacja.cs` po Id.
| 11 | Programowanie asynchroniczne | Stworzono asynchroniczną funkcje `WyslijPotwierdzenieAsync()` w klasie `Rezerwacja.cs` do wysylania e-maila. Funkcja nie posiada implementacji, została dodana w celach demonstracyjnych. |
| 12 | Refleksja | W metodzie `WypiszSzczegoly()` w klasie `Rezerwacja.cs` użyto `GetType().GetProperties()` opartej na refleksji. Metoda `WypiszSzczegoly()` wypisuje wszystkie pola i ich wartosci dla obiektu klasy `Rezerwacja.cs`.|
| 13 | Pattern matching (dodatkowo) | Metoda `Rezerwacja.Status()` w klasie `Rezerwacja.cs` wykorzystuje pattern matching i porównuje wartość pola obiektu `Data` z `DateTime.Now`. Zwraca informację o statusie danej rezerwacji. |

## Pliki

```
EscapeRoomManager.csproj
Program.cs              # demo
EscapeRoom.cs           # klasa abstrakcyjna
KlasycznyPokoj.cs       # podklasa
PokojVR.cs              # podklasa
Klient.cs               # klasa
Rezerwacja.cs           # klasa
KalkulatorCen.cs        # klasa statyczna
IRezerwacja.cs          # interfejs
Repozytorium.cs         # klasa generyczna
README.md
```
