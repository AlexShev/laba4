namespace laba4.FarmDogs;

public class DogCase<T> where T : class, IDog
{
    private T? _dog;
    public bool IsDirty { get; private set; } = false;
    public bool IsEmpty => _dog == null;

    public DogCase()
    {
        _dog = null;
    }

    public DogCase(T dog)
    {
        _dog = dog;
    }

    public void SetDog(T dog)
    {
        _dog = dog;
    }

    public T? GetDog()
    {
        T? dog = _dog;
        _dog = null;
        return dog;
    }

    public T Show()
    {
        return _dog;
    }

    

    public void Fead(IFeader feader)
    {
        if (_dog != null)
        {
            feader.Fead(_dog);
            IsDirty = true;
        }
    }

    public void Clean()
    {
        IsDirty = false;
    }
}
