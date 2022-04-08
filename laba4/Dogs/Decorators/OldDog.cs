namespace laba4.Decorators;

public sealed class OldDog : ImprovedDog
{
    public const int MAX_AGE = 16;

    public const int ENERGY_CONSUPTION = 75;

    private readonly AdultDog _adultDog;
    
    // старой собакой может  быть только взрослая собака
    public OldDog(AdultDog dog) : base(dog)
    {
        _adultDog = dog;
    }


    public string Existe()
    {
        GetHungry(ENERGY_CONSUPTION);
        return $"Эх, а ведь в былые времена, я {Name} был {_adultDog.NameOfSpecialty}";
    }
}
