namespace laba4.FarmDogs.Veterinarians;

public interface IVeterinarian
{
    bool Cure(IDog dog);
    bool InspectDog(IDog dog);
}
