namespace EscapeRoomManager;

public class KlasycznyPokoj : EscapeRoom
{
    public string Tematyka { get; }

    public KlasycznyPokoj(string nazwa, int maksOsob, string lokalizacja, string tematyka)
        : base(nazwa, maksOsob, lokalizacja)
    {
        Tematyka = tematyka;
    }

    public override decimal Cena() => 250m;
}
