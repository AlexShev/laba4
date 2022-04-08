namespace laba4.Decorators;

// по сути это паттерн налл обжект
public sealed class UnemployedDog : AdultDog
{
    public UnemployedDog(Puppy dog) : base(dog, Professions.UnemployedDog.Instens) { }

    public override string DoWork()
    {
        _dog.GetHungry(ENERGY_CONSUPTION);

        return $"{_dog.Name}, и я безработный(";
    }
}
