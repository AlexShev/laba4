using laba4.Decorators;
using System.Text;

namespace laba4.PlaceOfWork;

public abstract class WorkPlace
{
    public abstract string Name { get; }

    protected IList<AdultDog> _workers = new List<AdultDog>();

    public abstract bool CanEmploy(AdultDog worker);

    public bool AddWorkerForDayWork(AdultDog worker)
    {
        if (CanEmploy(worker))
        {
            _workers.Add(worker);
            return true;
        }
        else
        {
            return false;
        }
    }

    public string SimulateWorkingDay()
    {
        return SimulateWorkingDay(_workers);
    }

    public IList<AdultDog> GetWorkers()
    {
        var temp = _workers;
        _workers = new List<AdultDog>();
        return temp;
    }

    public void CloseWorkPlace()
    {
        _workers = new List<AdultDog>();
    }

    protected virtual string SimulateWorkingDay(IList<AdultDog> workers)
    {
        StringBuilder stringBuilder = new();

        foreach (var worker in workers)
        {
            stringBuilder.AppendLine(worker.DoWork());
        }

        return stringBuilder.ToString();
    }
}
