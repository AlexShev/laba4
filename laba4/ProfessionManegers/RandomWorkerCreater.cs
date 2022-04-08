using laba4.Decorators;
using laba4.Professions;

namespace laba4.ProfessionManegers;

public class RandomWorkerCreater : WorkerCreater<Puppy, AdultDog>
{
    private static readonly Random _random = new Random();

    public RandomWorkerCreater()
    {
        AddWorkerProducer(new UnemployedDogProduser());
        AddWorkerProducer(new PoliceDogProduser());
        AddWorkerProducer(new RescueServiceDogProduser());
    }

    public override AdultDog Create(Puppy workable)
    {
        int index = _random.Next(_produseres.Count);

        return _produseres.ElementAt(index).Value.Create(workable);
    }
}
