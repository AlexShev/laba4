using laba4.Professions;
using System.Text;

namespace laba4.PlaceOfWork;

public abstract class WorkPlace
{
    public abstract string Name { get; }

    protected IDictionary<Guid, Profession> _professions = new Dictionary<Guid, Profession>();
    protected IDictionary<Guid, IList<IWorker>> _workers = new Dictionary<Guid, IList<IWorker>>();

    public void AddProfession(Profession profession)
    {
        if (!IsMyProfession(profession.ID))
        {
            _professions.Add(profession.ID, profession);
            _workers.Add(profession.ID, new List<IWorker>());
        }
    }

    public bool IsMyProfession(Guid id) => _professions.ContainsKey(id);
    public bool CanEmploy(IWorker worker) => _professions.ContainsKey(worker.IDofSpecialty);

    public bool AddWorkerForDayWork(IWorker worker)
    {
        if (CanEmploy(worker))
        {
            _workers[worker.IDofSpecialty].Add(worker);
            return true;
        }
        else
        {
            return false;
        }
    }

    // не забыть логгер
    public string SimulateWorkingDay()
    {
        string res = SimulateWorkingDay(_workers);

        return res;
    }

    public IDictionary<Guid, IList<IWorker>> GetWorkers()
    {
        return _workers;
    }

    public void CloseWorkPlace()
    {
        _workers = new Dictionary<Guid, IList<IWorker>>();

        foreach (var prof in _professions)
        {
            _workers.Add(prof.Key, new List<IWorker>());
        }
    }

    protected virtual string SimulateWorkingDay(IDictionary<Guid, IList<IWorker>> workers)
    {
        StringBuilder stringBuilder = new();

        foreach (var department in workers)
        {
            stringBuilder.AppendLine($"Работники профессии {_professions[department.Key]}:");

            foreach (var worker in department.Value)
            {
                stringBuilder.AppendLine(worker.DoWork());
            }
        }

        return stringBuilder.ToString();
    }
}
