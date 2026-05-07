namespace EscapeRoomManager;

public interface IRezerwacja
{
    string Nazwa { get; }
    bool Dostepny(DateTime data);
}
