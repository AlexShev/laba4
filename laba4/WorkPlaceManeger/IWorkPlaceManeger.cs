using laba4.PlaceOfWork;

namespace laba4.WorkPlaceManeger;

public interface IWorkPlaceManeger
{
    bool PutToWork(IWorker worker);

    void AddWorkPlace(WorkPlace workPlace);

    IList<WorkPlace> GetAllWorkPlaces();
}
