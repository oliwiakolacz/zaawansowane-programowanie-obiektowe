namespace EscapeRoomManager;

public class Klient
{
    public string Imie { get; }
    public string Nazwisko { get; }
    public string Email { get; private set; }

    public Klient(string imie, string nazwisko, string email)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Email = email;
    }

    public void ZmienEmail(string nowyEmail)
    {
        if (string.IsNullOrWhiteSpace(nowyEmail))
            throw new ArgumentException("Email nie może być pusty");
        Email = nowyEmail;
    }
}
