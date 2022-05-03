using laba4.Decorators;
using laba4.ProfessionManegers;

namespace laba4.Generators;

public class DogGenerator
{
    private static readonly IList<string> _names = new List<string>()
    {
        "Mike",
        "Барсик",
        "Генрих",
        "Людовик",
        "Пушок",
        "Персик",
        "Вангог",
        "Борис",
        "Кате"
    };

    private IAdultFactoryManeger _workerCreater;

    public DogGenerator(IAdultFactoryManeger workerCreater)
    {
        _workerCreater = workerCreater;
    }

    private static readonly Random _random = new Random();

    private static string GenerateName() => _names[_random.Next(_names.Count)];

    private static int GenerateHelthLevel() => _random.Next(IDog.MIN_HELTHY_NORMA, IDog.MAX_HELTH_LEVEL);

    private static int GenerateTrainigLevel(int months)
    {
        double max_puppy_month = 12 * Puppy.MAX_AGE;
        return Math.Min((int)((IDog.MAX_TRAING_LEVEL - IDog.MIN_TRAING_LEVEL) * months / max_puppy_month), IDog.MAX_TRAING_LEVEL);
    }

    private static int GenerateSatietyLevel() => _random.Next(IDog.MIN_SATIETY_LEVEL, IDog.MAX_SATIETY_LEVEL);
    private static DateTime GetDateTime(int months) => DateTime.Now.AddMonths(-months).AddDays(-_random.Next(31));

    public Puppy GeneratePuppy(int months)
    {
        return new Puppy(GenerateName(),
                         GetDateTime(months),
                         GenerateHelthLevel(),
                         GenerateTrainigLevel(months),
                         GenerateSatietyLevel()
        );
    }

    public Puppy GeneratePuppy()
    {
        int months = _random.Next(0, Puppy.MAX_AGE * 12 + 1);

        return new Puppy(GenerateName(),
                         GetDateTime(months),
                         GenerateHelthLevel(),
                         GenerateTrainigLevel(months),
                         GenerateSatietyLevel()
        );
    }

    public AdultDog GenereteAdultDog()
    {
        int months = _random.Next(Puppy.MAX_AGE, AdultDog.MAX_AGE) * 12;

        return (AdultDog)_workerCreater.Create(GeneratePuppy(months));
    }

    public AdultDog GenereteAdultDog(int months)
    {
        return (AdultDog)_workerCreater.Create(GeneratePuppy(months));
    }

    public OldDog GenereteOldDog()
    {
        int months = _random.Next(AdultDog.MAX_AGE, OldDog.MAX_AGE) * 12;

        return new OldDog(GenereteAdultDog(months));
    }

    public IList<OldDog> GenereteOldDogs(int num)
    {
        IList<OldDog> list = new List<OldDog>(num);

        for (int i = 0; i < num; i++)
        {
            list.Add(GenereteOldDog());
        }

        return list;
    }

    public IList<AdultDog> GenereteAdultDogs(int num)
    {
        IList<AdultDog> list = new List<AdultDog>(num);

        for (int i = 0; i < num; i++)
        {
            list.Add(GenereteAdultDog());
        }

        return list;
    }

    public IList<Puppy> GeneratePuppys(int num)
    {
        IList<Puppy> list = new List<Puppy>(num);

        for (int i = 0; i < num; i++)
        {
            list.Add(GeneratePuppy());
        }

        return list;
    }
}
