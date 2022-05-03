using laba4.Decorators;
using laba4.PlaceOfWork;

namespace laba4.WorkPlaceManeger;

public interface IWorkPlaceManeger
{
    bool PutToWork(AdultDog worker);

    IList<WorkPlace> GetAllWorkPlaces();
}
