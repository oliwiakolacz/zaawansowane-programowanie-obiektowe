using EscapeRoomManager;

EscapeRoom pokoj1 = new KlasycznyPokoj("Grobowiec", 6, "Gdańsk - Wrzeszcz", "horror");
EscapeRoom pokoj2 = new PokojVR("Galaktyczna stacja", 4, "Gdańsk - Centrum", liczbaOkularowVR: 4);

Console.WriteLine($"{pokoj1} - cena: {pokoj1.Cena()} zł");
Console.WriteLine($"{pokoj2} - cena: {pokoj2.Cena()} zł");

var klient = new Klient("Oliwia", "Kołacz", "oliwia.kolacz@example.com");

var repo = new Repozytorium<Rezerwacja>();
repo.Dodano += r => Console.WriteLine($"Dodano rezerwację {r.Id}");
repo.Usunieto += r => Console.WriteLine($"Usunięto rezerwację {r.Id}");

var rezerwacja1 = new Rezerwacja(pokoj1, klient, DateTime.Now.AddDays(3));
var rezerwacja2 = new Rezerwacja(pokoj2, klient, DateTime.Now.AddDays(-1)); // przeszłość

repo.Dodaj(rezerwacja1);
repo.Dodaj(rezerwacja2);

Console.WriteLine($"\nLiczba rezerwacji: {Rezerwacja.LiczbaWszystkich}");

await rezerwacja1.WyslijPotwierdzenieAsync();

Console.WriteLine();
rezerwacja1.WypiszSzczegoly();

Console.WriteLine($"\nStatus rezerwacja1: {rezerwacja1.Status()}");
Console.WriteLine($"Status rezerwacja2: {rezerwacja2.Status()}");

Console.WriteLine($"\nrezerwacja1 == rezerwacja2: {rezerwacja1 == rezerwacja2}");
Console.WriteLine($"rezerwacja1 == rezerwacja1: {rezerwacja2 == rezerwacja1}");

Console.WriteLine($"\nrezerwacja1 == rezerwacja2: {rezerwacja1 != rezerwacja2}");
Console.WriteLine($"rezerwacja1 == rezerwacja1: {rezerwacja2 != rezerwacja1}");

var cenaZeZnizka = KalkulatorCen.ZeZnizka(rezerwacja1.Cena, 0.1);
Console.WriteLine($"\nCena ze zniżką 10%: {cenaZeZnizka} zł");

Console.WriteLine("\nModyfikacje rezerwacji");
rezerwacja1.PrzesunNa(DateTime.Now.AddDays(7));
Console.WriteLine($"Nowa data: {rezerwacja1.Data}");

rezerwacja1.ZastosujZnizke(0.15);
Console.WriteLine($"Po zniżce 15%: {rezerwacja1.Cena} zł");

klient.ZmienEmail("oliwia.kolacz@email.com");
Console.WriteLine($"Nowy email klienta: {klient.Email}");

Console.WriteLine("\nUsuwam rezerwacje z datą przeszłą");
int usunieto = repo.Usun(r => r.Data < DateTime.Now);
Console.WriteLine($"Usunięto: {usunieto}");
Console.WriteLine($"Pozostało w repozytorium: {repo.Liczba}");
