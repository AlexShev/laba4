using laba4.Decorators;

namespace laba4.Professions;

public abstract class Profession
{
    public Guid ID { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }

    protected Profession(string name)
    {
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        if (GetType() == obj?.GetType())
        {
            return ID == ((Profession)obj).ID;
        }

        return false;
    }

    public override string ToString()
    {
        return Name;
    }
}
