using EscapeRoomManager;

Console.WriteLine("------------------------------");

// Tworzenie dwoch pokoi
EscapeRoom pokoj1 = new KlasycznyPokoj("Grobowiec", 6, "Gdańsk - Wrzeszcz", "horror");
EscapeRoom pokoj2 = new PokojVR("Galaktyczna stacja", 4, "Gdańsk - Centrum", liczbaOkularowVR: 4);
Console.WriteLine($"{pokoj1} - cena: {pokoj1.Cena()} zł");
Console.WriteLine($"{pokoj2} - cena: {pokoj2.Cena()} zł");

Console.WriteLine("\n------------------------------");

// Tworzenie klienta
var klient1 = new Klient("Oliwia", "Kołacz", "oliwia.kolacz@example.com");
Console.WriteLine($"{klient1} - Imie: {klient1.Imie}, Nazwisko: {klient1.Nazwisko},  Email: {klient1.Email}");

// Tworzenie repozytorium z rezerwacjami (klasa generyczna)
var repo = new Repozytorium<Rezerwacja>();

// Definiowanie zdarzeń
repo.Dodano += r => Console.WriteLine($"Dodano rezerwację {r.Id}");
repo.Usunieto += r => Console.WriteLine($"Usunięto rezerwację {r.Id}");

// Tworzenie dwoch rezerwacji - jednej z data przyszla a druga z data przeszla w celu demonstracyjnym
var rezerwacja1 = new Rezerwacja(pokoj1, klient1, DateTime.Now.AddDays(3));
var rezerwacja2 = new Rezerwacja(pokoj2, klient1, DateTime.Now.AddDays(-1));

Console.WriteLine("\n------------------------------");

// Dodawanie rezerwacji do repozytorium - wykona sie rowniez zdarzenie "Dodano" - wypisze tekst "Dodano rezerwacje"
repo.Dodaj(rezerwacja1);
repo.Dodaj(rezerwacja2);

Console.WriteLine("\n------------------------------");

// Indeksator, dostęp do elementów repozytorium jak do tablicy
Console.WriteLine($"Pierwsza rezerwacja w repo (repo[0]): {repo[0].Id}");
Console.WriteLine($"Druga rezerwacja w repo (repo[1]): {repo[1].Id}");

Console.WriteLine("\n------------------------------");

// Wypisanie wartosci statycznego pola - licznik rezerwacji
Console.WriteLine($"Liczba rezerwacji: {Rezerwacja.LiczbaWszystkich}");

Console.WriteLine("\n------------------------------");

// Wykonanie asynchrinicznej fukcji i poczekanie na rezultat
await rezerwacja1.WyslijPotwierdzenieAsync();

Console.WriteLine("\n------------------------------");

// Wypisanie szczegolow rezerwacji z wykorzystaniem refleksji
rezerwacja1.WypiszSzczegoly();

Console.WriteLine("\n------------------------------");

// Wypisanie statusu rezerwacji z wykorzystaniem pattern matching
Console.WriteLine($"Status rezerwacja1: {rezerwacja1.Status()}");
Console.WriteLine($"Status rezerwacja2: {rezerwacja2.Status()}");

Console.WriteLine("\n------------------------------");

// Sprawdzanie przeciazonych operatorow
Console.WriteLine($"rezerwacja1 == rezerwacja2: {rezerwacja1 == rezerwacja2}");
Console.WriteLine($"rezerwacja1 == rezerwacja1: {rezerwacja2 == rezerwacja1}");
Console.WriteLine($"rezerwacja1 != rezerwacja2: {rezerwacja1 != rezerwacja2}");
Console.WriteLine($"rezerwacja1 != rezerwacja1: {rezerwacja2 != rezerwacja1}");

Console.WriteLine("\n------------------------------");

// Uzycie statycznej metody ze statycznej klasy do obliczenia ceny
var cenaZeZnizka = KalkulatorCen.ZeZnizka(rezerwacja1.Cena, 0.1);
Console.WriteLine($"Cena ze zniżką 10%: {cenaZeZnizka} zł");

Console.WriteLine("\n------------------------------");

Console.WriteLine("Modyfikacje rezerwacji:");
rezerwacja1.PrzesunNa(DateTime.Now.AddDays(7));
Console.WriteLine($"Nowa data: {rezerwacja1.Data}");

Console.WriteLine("\n------------------------------");

rezerwacja1.ZastosujZnizke(0.15);
Console.WriteLine($"Po zniżce 15%: {rezerwacja1.Cena} zł");

Console.WriteLine("\n------------------------------");

klient1.ZmienEmail("oliwia.kolacz@email.com");
Console.WriteLine($"Nowy email klienta: {klient1.Email}");

Console.WriteLine("\n------------------------------");

// Usuwanie rezerwacji z wkorzystaniem delegacji (funkcji)
Console.WriteLine("Usuwam rezerwacje z datą przeszłą:");
int usunieto = repo.Usun(r => r.Data < DateTime.Now);
Console.WriteLine($"Usunięto: {usunieto}");
Console.WriteLine($"Pozostało w repozytorium: {repo.Liczba}");

