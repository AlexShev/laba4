using laba4.Decorators;
using laba4.Professions;

namespace laba4.ProfessionManegers;

public interface IAdultFactoryManeger
{
    AdultDog Create(Guid professionID, Puppy workable);
    AdultDog Create(Puppy workable);
}
