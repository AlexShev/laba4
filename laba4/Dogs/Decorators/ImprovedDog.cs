namespace laba4.Decorators;

public abstract class ImprovedDog : IDog
{
    protected readonly IDog _dog;
    public Guid ID => _dog.ID;
    public string Name => _dog.Name;
    public double Age => _dog.Age;
    public int HelthLevel => _dog.HelthLevel;
    public int SatietyLevel => _dog.SatietyLevel;
    public int TrainingLevel => _dog.TrainingLevel;

    public ImprovedDog(IDog dog)
    {
        _dog = dog;
    }

    public virtual bool Eat(int food)
    {
        return _dog.Eat(food);
    }

    public virtual bool GetHungry(int energyСonsumption)
    {
        return _dog.GetHungry(energyСonsumption);
    }

    public virtual bool Recover(int hp)
    {
        return _dog.Recover(hp);
    }

    public override string ToString()
    {
        return _dog.ToString() ?? string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return _dog.Equals(obj);
    }
}
