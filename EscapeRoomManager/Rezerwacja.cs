namespace EscapeRoomManager;

public class Rezerwacja
{
    public static int LiczbaWszystkich { get; private set; } = 0;

    public Guid Id { get; }
    public EscapeRoom Pokoj { get; }
    public Klient Klient { get; }
    public DateTime Data { get; private set; }
    public decimal Cena { get; private set; }

    public Rezerwacja(EscapeRoom pokoj, Klient klient, DateTime data, decimal cena)
    {
        Id = Guid.NewGuid();
        Pokoj = pokoj;
        Klient = klient;
        Data = data;
        Cena = cena;
        LiczbaWszystkich++;
    }

    public Rezerwacja(EscapeRoom pokoj, Klient klient, DateTime data)
        : this(pokoj, klient, data, pokoj.Cena()) { }

    public void PrzesunNa(DateTime nowaData)
    {
        if (nowaData < DateTime.Now)
            throw new ArgumentException("Nie można rezerwować w przeszłości");
        Data = nowaData;
    }

    public void ZastosujZnizke(double procent)
    {
        Cena = KalkulatorCen.ZeZnizka(Cena, procent);
    }

    public async Task WyslijPotwierdzenieAsync()
    {
        Console.WriteLine($"Wysyłanie potwierdzenia do {Klient.Email}...");
        await Task.Delay(1000);
        Console.WriteLine("Potwierdzenie wysłane.");
    }

    public void WypiszSzczegoly()
    {
        Console.WriteLine($"Szczegóły rezerwacji:");
        foreach (var prop in GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(this)}");
        }
    }

    public string Status() => Data switch
    {
        var d when d < DateTime.Now => "Zakończona",
        var d when d < DateTime.Now.AddDays(1) => "Dziś",
        var d when d < DateTime.Now.AddDays(7) => "W tym tygodniu",
        _ => "Zaplanowana"
    };

    public static bool operator ==(Rezerwacja? left, Rezerwacja? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Id == right.Id;
    }

    public static bool operator !=(Rezerwacja? left, Rezerwacja? right) => !(left == right);

    public override bool Equals(object? obj) => obj is Rezerwacja r && this == r;
    public override int GetHashCode() => Id.GetHashCode();
}
