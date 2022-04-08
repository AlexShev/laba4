using System.Text;

namespace laba4;

public abstract class Dog : IDog
{
    public Guid ID { get; private set; } = Guid.NewGuid();

    private readonly DateTime _birthday;
    private int _helthLevel;
    private int _satietyLevel;

    public string Name { get; private set; }
    public double Age => (DateTime.Today.Subtract(_birthday).TotalDays) / 365.2425;
    public int HelthLevel => _helthLevel;
    public int SatietyLevel => _satietyLevel;
    public abstract int TrainingLevel { get; }

    public Dog(string name, DateTime birthday, int helthLevel, int satietyLevel)
    {
        Name = name;
        _birthday = birthday;
        _helthLevel = CheckCorrectErr(helthLevel, IDog.MAX_HELTH_LEVEL, IDog.MIN_HELTH_LEVEL);
        _satietyLevel = CheckCorrectErr(satietyLevel, IDog.MAX_SATIETY_LEVEL, IDog.MIN_SATIETY_LEVEL);
    }

    public Dog(string name, DateTime birthday) : this(
        name: name,
        birthday: birthday,
        helthLevel: IDog.MAX_HELTH_LEVEL,
        satietyLevel: IDog.MAX_SATIETY_LEVEL) { }

    public bool Recover(int hp)
    {
        return IncreaseField(ref _helthLevel, hp, IDog.MAX_HELTH_LEVEL, IDog.MIN_HELTHY_NORMA);
    }

    public bool Eat(int food)
    {
        return IncreaseField(ref _satietyLevel, food, IDog.MAX_SATIETY_LEVEL, IDog.MIN_SATIETY_NORMA);
    }

    public bool GetHungry(int energyСonsumption)
    {
        return !DecreaseField(ref _satietyLevel, energyСonsumption, IDog.MIN_SATIETY_LEVEL, IDog.MIN_SATIETY_NORMA);
    }

    public override string ToString()
    {
        return new StringBuilder()
            .Append("Кличка: ").Append(Name).Append(", ")
            .Append("Возраст: ").Append(Math.Round(Age, 1)).Append(", ")
            .Append("Уровень здоровья: ").Append(_helthLevel).Append(", ")
            .Append("Уровень сытости: ").Append(_satietyLevel)
            .ToString();
    }

    public override bool Equals(object? obj)
    {
        if (GetType() == obj?.GetType())
        {
            return ID == ((Dog)obj).ID;
        }

        return false;
    }

    protected static bool IncreaseField(ref int var, int inc, int max, int border)
    {
        var += inc;

        if (var > max)
        {
            var = max;
        }

        return var >= border;
    }

    protected static bool DecreaseField(ref int var, int inc, int min, int border)
    {
        int oldVar = var;

        if (var - inc >= min)
        {
            var -= inc;

            return oldVar >= border;
        }

        return false;
    }

    protected static int CheckCorrectErr(int var, int max, int min)
    {
        if (min > var || max < var)
        {
            throw new AggregateException($"не валидный аргумент со значением {var}");
        }

        return var;
    }
}

/*
 * 
    public Dog(Dog dog) : this(
        name: dog.Name,
        birthday: dog._birthday,
        helthLevel: dog._helthLevel,
        satietyLevel: dog._satietyLevel) { }
 */