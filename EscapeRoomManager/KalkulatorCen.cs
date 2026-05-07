namespace EscapeRoomManager;

public static class KalkulatorCen
{
    public static decimal ZeZnizka(decimal cena, double procent)
        => cena * (decimal)(1.0 - procent);

    public static decimal CenaWeekendowa(decimal cena)
        => cena * 1.2m;
}
