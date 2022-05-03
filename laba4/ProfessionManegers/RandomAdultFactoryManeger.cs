using laba4.Decorators;
using laba4.Professions;

namespace laba4.ProfessionManegers;

public class RandomAdultFactoryManeger : IAdultFactoryManeger
{
    private static readonly Random _random = new Random();

    private readonly IDictionary<Guid, IAdultDogFactory> _produseres = new Dictionary<Guid, IAdultDogFactory>();

    public bool AddWorkerProducer(IAdultDogFactory workerProducer)
    {
        if (!_produseres.ContainsKey(workerProducer.GetAdultDogFactoryId()))
        {
            _produseres.Add(workerProducer.GetAdultDogFactoryId(), workerProducer);
            return true;
        }

        return false;
    }


    public RandomAdultFactoryManeger()
    {
        AddWorkerProducer(new UnemployedDogFactory());
        AddWorkerProducer(new PoliceDogFactory());
        AddWorkerProducer(new RescueServiceDogFactory());
    }

    public AdultDog Create(Puppy workable)
    {
        int index = _random.Next(_produseres.Count);
        // обучаем случайной профессии
        return _produseres.ElementAt(index).Value.Create(workable);
    }

    public AdultDog Create(Guid professionID, Puppy workable)
    {
        if (_produseres.ContainsKey(professionID))
        {
            return _produseres[professionID].Create(workable);
        }

        // если нет подходящей профессии - возвращаем безработную собаку
        return _produseres[UnemployedDogFactory.AdultDogFactoryId].Create(workable);
    }
}
