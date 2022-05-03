namespace laba4.ProfessionManegers;

class UnemployedDogFactory : IAdultDogFactory
{
    public static Guid AdultDogFactoryId => Professions.UnemployedDog.Instens.ID;

    public Guid GetAdultDogFactoryId() => AdultDogFactoryId;

    public Decorators.AdultDog Create(Puppy puppy)
    {
        return new Decorators.UnemployedDog(puppy);
    }
}
