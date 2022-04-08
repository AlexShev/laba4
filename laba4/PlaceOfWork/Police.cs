using laba4.Professions;

namespace laba4.PlaceOfWork;

public class Police : WorkPlace
{
    public override string Name => "Полицейский участок";

    public Police()
    {
        AddProfession(PoliceDog.Instens);
    }

    protected override string SimulateWorkingDay(IDictionary<Guid, IList<IWorker>> workers)
    {
        return $"{Name}:\n" + base.SimulateWorkingDay(workers);
    }
}
