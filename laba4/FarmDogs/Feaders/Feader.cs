using laba4.Decorators;
namespace laba4.FarmDogs;

public class Feader : IFeader
{
    public void Fead(IDog dog)
    {
        double age = dog.Age;

        if (age <= Puppy.MAX_AGE)
        {
            dog.Eat((int)(Puppy.ENERGY_CONSUPTION * 1.5));
        }
        else if (age <= AdultDog.MAX_AGE)
        {
            dog.Eat((int)(AdultDog.ENERGY_CONSUPTION * 1.5));
        }
        else
        {
            dog.Eat((int)(OldDog.ENERGY_CONSUPTION * 1.5));
        }
    }
}
