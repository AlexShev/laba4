namespace laba4.Decorators;

public sealed class PoliceDog : AdultDog
{
    public PoliceDog(Puppy dog) : base(dog, Professions.PoliceDog.Instens) { }

    public override string DoWork()
    {
        if (ReadyToWork)
        {
            return base.DoWork() + ", бойся меня преступник!";
        }
        else
        {
            return base.DoWork() + ",но я пока не могу работать";
        }
    }
}
