namespace EscapeRoomManager;

public abstract class EscapeRoom : IRezerwacja
{
    public string Nazwa { get; }
    public int MaksOsob { get; }
    public string Lokalizacja { get; }

    protected EscapeRoom(string nazwa, int maksOsob, string lokalizacja)
    {
        Nazwa = nazwa;
        MaksOsob = maksOsob;
        Lokalizacja = lokalizacja;
    }

    public virtual decimal Cena() => 200m;

    public bool Dostepny(DateTime data) => data.Hour >= 10 && data.Hour < 22;
}
