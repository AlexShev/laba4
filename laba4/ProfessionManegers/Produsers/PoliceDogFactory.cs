namespace laba4.ProfessionManegers;

class PoliceDogFactory : IAdultDogFactory
{
    public static Guid AdultDogFactoryId => Professions.PoliceDog.Instens.ID;

    public Guid GetAdultDogFactoryId() => AdultDogFactoryId;


    public Decorators.AdultDog Create(Puppy puppy)
    {
        return new Decorators.PoliceDog(puppy);
    }
}
