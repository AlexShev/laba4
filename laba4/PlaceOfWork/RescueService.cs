using laba4.Professions;

namespace laba4.PlaceOfWork;

public class RescueService : WorkPlace
{
    public override string Name => "Служба спасения";

    public RescueService()
    {
        AddProfession(RescueServiceDog.Instens);
    }

    protected override string SimulateWorkingDay(IDictionary<Guid, IList<IWorker>> workers)
    {
        return $"{Name}:\n" + base.SimulateWorkingDay(workers);
    }
}