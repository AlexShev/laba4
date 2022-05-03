using laba4.Professions;

namespace laba4.PlaceOfWork;

public class RescueService : WorkPlace
{
    public override string Name => "Служба спасения";

    public override bool CanEmploy(laba4.Decorators.AdultDog worker)
    {
        return worker.IDofSpecialty == laba4.Professions.RescueServiceDog.Instens.ID;
    }

    protected override string SimulateWorkingDay(IList<laba4.Decorators.AdultDog> workers)
    {
        return $"{Name}:\n" + base.SimulateWorkingDay(workers);
    }
}