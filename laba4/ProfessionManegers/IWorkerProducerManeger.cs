using laba4.Professions;

namespace laba4.ProfessionManegers;

public interface IWorkerProducerManeger<ConcrateWorkable, ConcrateWorker>
    where ConcrateWorkable : class, IWorkable
    where ConcrateWorker : class, IWorker
{
    ConcrateWorker Create(Guid professionID, ConcrateWorkable workable);
    ConcrateWorker Create(ConcrateWorkable workable);

    bool AddWorkerProducer(IWorkerProducer<ConcrateWorkable, ConcrateWorker> workerProducer);
    bool RemoveWorkerProducer(Guid workerProducerID);
}
