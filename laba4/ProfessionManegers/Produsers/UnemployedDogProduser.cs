namespace laba4.ProfessionManegers;

class UnemployedDogProduser : IWorkerProducer<Puppy, Decorators.AdultDog> // Decorators.UnemployedDog>
{
    public static Guid WorkerProducerId => Professions.UnemployedDog.Instens.ID;

    public Decorators.AdultDog Create(Puppy puppy)
    {
        return new Decorators.UnemployedDog(puppy);
    }

    public Guid GetWorkerProducerId()
    {
        return Professions.UnemployedDog.Instens.ID;
    }
}
