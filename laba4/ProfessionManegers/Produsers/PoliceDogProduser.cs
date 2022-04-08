namespace laba4.ProfessionManegers;

class PoliceDogProduser : IWorkerProducer<Puppy, Decorators.AdultDog>
{
    public static Guid WorkerProducerId => Professions.PoliceDog.Instens.ID;

    public Decorators.AdultDog Create(Puppy puppy)
    {
        return new Decorators.PoliceDog(puppy);
    }

    public Guid GetWorkerProducerId()
    {
        return Professions.PoliceDog.Instens.ID;
    }
}
