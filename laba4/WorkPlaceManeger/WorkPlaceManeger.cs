using laba4.Decorators;
using laba4.PlaceOfWork;

namespace laba4.WorkPlaceManeger;

public class WorkPlaceManeger : IWorkPlaceManeger
{
    private IList<WorkPlace> _workPlaceList;

    public WorkPlaceManeger(IList<WorkPlace> workPlaceList)
    {
        _workPlaceList = workPlaceList;
    }

    public IList<WorkPlace> GetAllWorkPlaces()
    {
        return _workPlaceList;
    }

    public bool PutToWork(AdultDog worker)
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
