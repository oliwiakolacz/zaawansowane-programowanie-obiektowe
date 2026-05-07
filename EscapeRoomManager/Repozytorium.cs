namespace EscapeRoomManager;

public class Repozytorium<T> where T : class
{
    private readonly List<T> _elementy = new();

    public event Action<T>? Dodano;
    public event Action<T>? Usunieto;

    public int Liczba => _elementy.Count;

    public T this[int indeks] => _elementy[indeks];

    public void Dodaj(T element)
    {
        _elementy.Add(element);
        Dodano?.Invoke(element);
    }

    public int Usun(Func<T, bool> warunek)
    {
        var doUsuniecia = _elementy.Where(warunek).ToList();
        foreach (var el in doUsuniecia)
        {
            _elementy.Remove(el);
            Usunieto?.Invoke(el);
        }
        return doUsuniecia.Count;
    }
}
