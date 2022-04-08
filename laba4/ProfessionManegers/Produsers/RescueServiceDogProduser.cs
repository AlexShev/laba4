namespace laba4.ProfessionManegers;

class RescueServiceDogProduser : IWorkerProducer<Puppy, Decorators.AdultDog>
{
    public static Guid WorkerProducerId => Professions.RescueServiceDog.Instens.ID;

    public Decorators.AdultDog Create(Puppy puppy)
    {
        return new Decorators.RescueServiceDog(puppy);
    }

    public Guid GetWorkerProducerId()
    {
        return Professions.RescueServiceDog.Instens.ID;
    }
}
