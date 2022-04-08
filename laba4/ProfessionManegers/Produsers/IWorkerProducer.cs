using laba4.Professions;

namespace laba4.ProfessionManegers;

public interface IWorkerProducer<ConcrateWorkable, ConcrateWorker> 
    where ConcrateWorkable : class, IWorkable
    where ConcrateWorker : class, IWorker
{
    static Guid WorkerProducerId { get; }
    Guid GetWorkerProducerId();

    ConcrateWorker Create(ConcrateWorkable workable);
}
