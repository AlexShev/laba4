using laba4.Professions;
namespace laba4.Decorators;

public abstract class AdultDog : ImprovedDog, IWorker
{
    public const int MAX_AGE = 8;
    public const int ENERGY_CONSUPTION = 65;

    protected readonly Profession _profession;
    
    protected AdultDog(IDog dog, Profession profession) : base(dog) 
    {
        _profession = profession;
    }

    public virtual string DoWork()
    {
        GetHungry(ENERGY_CONSUPTION);

        return $"Я {Name} и моя профессия {_profession.Name}";
    }

    public string NameOfSpecialty => _profession.Name;

    public Guid IDofSpecialty => _profession.ID;

    public bool ReadyToWork => _dog.SatietyLevel >= ENERGY_CONSUPTION && _dog.HelthLevel >= IDog.MIN_HELTHY_NORMA;

    public override string ToString()
    {
        return $"{base.ToString()}, профессия {NameOfSpecialty}";
    }
}
