namespace laba4.FarmDogs.Veterinarians;

public class SimpleVeterinarian : IVeterinarian
{
    private const int HP = 20;

    public bool Cure(IDog dog)
    {
        return dog.Recover(HP);
    }

    public bool InspectDog(IDog dog)
    {
        return dog.HelthLevel > IDog.MIN_HELTHY_NORMA;
    }
}
