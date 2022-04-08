using laba4.Professions;

namespace laba4.ProfessionManegers;

public abstract class WorkerCreater<ConcrateWorkable, ConcrateWorker> : IWorkerProducerManeger<ConcrateWorkable, ConcrateWorker>
    where ConcrateWorkable : class, IWorkable
    where ConcrateWorker : class, IWorker
{
    protected readonly IDictionary<Guid, IWorkerProducer<ConcrateWorkable, ConcrateWorker>> _produseres = new Dictionary<Guid, IWorkerProducer<ConcrateWorkable, ConcrateWorker>>();

    public bool AddWorkerProducer(IWorkerProducer<ConcrateWorkable, ConcrateWorker> workerProducer)
    {
        if (!_produseres.ContainsKey(workerProducer.GetWorkerProducerId()))
        {
            _produseres.Add(workerProducer.GetWorkerProducerId(), workerProducer);
            return true;
        }

        return false;
    }

    public ConcrateWorker Create(Guid professionID, ConcrateWorkable workable)
    {
        if (workable is Puppy && _produseres.ContainsKey(professionID))
        {
            return _produseres[professionID].Create(workable);
        }

        return null;
    }

    public abstract ConcrateWorker Create(ConcrateWorkable workable);

    public bool RemoveWorkerProducer(Guid workerProducerID)
    {
        return _produseres.Remove(workerProducerID);
    }
}
