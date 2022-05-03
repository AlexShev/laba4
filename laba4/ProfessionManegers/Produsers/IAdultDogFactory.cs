using laba4.Decorators;

namespace laba4.ProfessionManegers;

public interface IAdultDogFactory
{
    static Guid AdultDogFactoryId { get; }
    Guid GetAdultDogFactoryId();

    AdultDog Create(Puppy workable);
}
