namespace EscapeRoomManager;

public class PokojVR : EscapeRoom
{
    public int LiczbaOkularowVR { get; private set; }

    public PokojVR(string nazwa, int maksOsob, string lokalizacja, int liczbaOkularowVR)
        : base(nazwa, maksOsob, lokalizacja)
    {
        LiczbaOkularowVR = liczbaOkularowVR;
    }

    public override decimal Cena() => 400m;

    public void DodajOkularyVR(int ile)
    {
        if (ile <= 0) throw new ArgumentException("Liczba okularów VR musi być dodatnia");
        LiczbaOkularowVR += ile;
    }
}
