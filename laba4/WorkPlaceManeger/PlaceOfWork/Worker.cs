namespace laba4;

public interface IWorker
{
    public Guid ID { get; }

    string DoWork();
    bool ReadyToWork { get; }
    string NameOfSpecialty { get; }
    public Guid IDofSpecialty { get; }
}
