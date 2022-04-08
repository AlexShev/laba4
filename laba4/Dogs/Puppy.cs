using laba4.Professions;

namespace laba4;

public class Puppy : Dog, IWorkable
{
    public const int MAX_AGE = 1;
    public const int ENERGY_CONSUPTION = 50;

    private int _trainingLevel = IDog.MIN_TRAING_LEVEL;
    public override int TrainingLevel => _trainingLevel;

    public Puppy(string name, DateTime birthday) : base(name, birthday) { }

    public Puppy(string name, DateTime birthday, int helthLevel, int trainingLevel, int satietyLevel)
        : base(name, birthday, helthLevel, satietyLevel)
    {
        _trainingLevel = CheckCorrectErr(trainingLevel, IDog.MAX_TRAING_LEVEL, IDog.MIN_TRAING_LEVEL);
    }

    public bool Training(int traing)
    {
        if (!GetHungry(ENERGY_CONSUPTION))
        {
            return IncreaseField(ref _trainingLevel, traing, IDog.MAX_TRAING_LEVEL, IDog.MIN_TRAING_NORMA);
        }
        else
        {
            return _trainingLevel >= IDog.MIN_TRAING_NORMA;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", Уровень тренерованности: {_trainingLevel}";
    }
}
