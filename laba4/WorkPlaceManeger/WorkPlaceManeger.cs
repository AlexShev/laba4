using laba4.PlaceOfWork;

namespace laba4.WorkPlaceManeger;

public class WorkPlaceManeger : IWorkPlaceManeger
{
    private IList<WorkPlace> _workPlaceList;

    public WorkPlaceManeger(IList<WorkPlace> workPlaceList)
    {
        _workPlaceList = workPlaceList;
    }

    public void AddWorkPlace(WorkPlace workPlace)
    {
        _workPlaceList.Add(workPlace);
    }

    public IList<WorkPlace> GetAllWorkPlaces()
    {
        return _workPlaceList;
    }

    public bool PutToWork(IWorker worker)
    {
        foreach (WorkPlace workPlace in _workPlaceList)
        {
            if (workPlace.CanEmploy(worker))
            {
                workPlace.AddWorkerForDayWork(worker);
                return true;
            }
        }

        return false;
    }
}
