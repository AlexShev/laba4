namespace laba4.Decorators;

public sealed class RescueServiceDog : AdultDog
{
    public RescueServiceDog(Puppy dog) : base(dog, Professions.RescueServiceDog.Instens) { }

    public override string DoWork()
    {
        if (ReadyToWork)
        {
            return base.DoWork() + ", не бойся, человек, я спасу тебя";
        }
        else
        {
            return base.DoWork() + ",но я пока не могу работать";
        }
    }
}
