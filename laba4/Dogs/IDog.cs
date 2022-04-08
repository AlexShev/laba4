namespace laba4;

public interface IDog
{
    public Guid ID { get; }
    string Name { get; }
    double Age { get; }
    int HelthLevel { get; }
    int SatietyLevel { get; }
    int TrainingLevel { get; }

    bool Recover(int hp); // выличиться
    bool Eat(int food); // поесть
    bool GetHungry(int energyСonsumption); // проголодастья 

    public const int MAX_HELTH_LEVEL = 100;
    public const int MIN_HELTH_LEVEL = 0;
    public const int MIN_HELTHY_NORMA = 80;

    public const int MAX_TRAING_LEVEL = 100;
    public const int MIN_TRAING_LEVEL = 0;
    public const int MIN_TRAING_NORMA = 80;

    public const int MAX_SATIETY_LEVEL = 100;
    public const int MIN_SATIETY_LEVEL = 0;
    public const int MIN_SATIETY_NORMA = 50;
}
