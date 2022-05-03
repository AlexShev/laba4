namespace laba4.ProfessionManegers;

class RescueServiceDogFactory : IAdultDogFactory
{
    public static Guid AdultDogFactoryId => Professions.RescueServiceDog.Instens.ID;

    public Guid GetAdultDogFactoryId() => AdultDogFactoryId;

    public Decorators.AdultDog Create(Puppy puppy)
    {
        return new Decorators.RescueServiceDog(puppy);
    }
}
