
using laba4.Decorators;
using laba4.WorkPlaceManeger;
using laba4.FarmDogs.Veterinarians;
using System.Text;
using laba4.Logers;
using laba4.StringFormaters;

namespace laba4.FarmDogs;

public class FarmDog
{
    private readonly IList<DogCase<Puppy>> _puppys = new List<DogCase<Puppy>>();
    private readonly IList<DogCase<AdultDog>> _adultDogs = new List<DogCase<AdultDog>>();
    private readonly IList<DogCase<OldDog>> _oldDogs = new List<DogCase<OldDog>>();

    private readonly IDictionary<Guid, int> _indexes = new Dictionary<Guid, int>();

    private readonly TrainingPark _trainingPark;
    private readonly IWorkPlaceManeger _workPlaces;
    private readonly IFeader _feader;
    private readonly IVeterinarian _veterinarian;

    private readonly ILoger _loger;

    public FarmDog(IList<Puppy> puppies,
                   IList<AdultDog> adultDogs,
                   IList<OldDog> oldDogs,
                   IWorkPlaceManeger workPlaces,
                   IFeader feader,
                   TrainingPark trainingPark,
                   IVeterinarian veterinarian,
                   ILoger loger)
    {
        Add(puppies);
        Add(adultDogs);
        Add(oldDogs);
        _workPlaces = workPlaces;
        _feader = feader;
        _trainingPark = trainingPark;
        _veterinarian = veterinarian;
        _loger = loger;
    }

    public void SimulateDay()
    {
        // кормёжка
        Feading();

        // осмотр
        InspectionDogs();

        // очистка вальеров
        CleaningCase();

        // тренеровка щенят
        Training();

        // работа взрослых собак
        Working();

        // жизнедеятельность старых собак
        Existing();

        // кормёжка
        Feading();

        // очистка вальеров
        CleaningCase();
    }

    private void CleaningCase()
    {
        _loger.Log("Чистка вальеров...");

        CleaningCase(_puppys);
        CleaningCase(_adultDogs);
        CleaningCase(_oldDogs);

        _loger.Log("Вальеры почищены");
        _loger.Log();

    }

    private void InspectionDogs()
    {
        _loger.Log("Проверка Собак");
        InspectionDogs(_puppys);
        InspectionDogs(_adultDogs);
        InspectionDogs(_oldDogs);
        _loger.Log();
    }

    private void Feading()
    {
        _loger.Log("Кормление собак:");
        Fead(_puppys);
        Fead(_adultDogs);
        Fead(_oldDogs);
        _loger.Log();
    }

    private void Fead<T>(IList<DogCase<T>> dogCases) where T : class, IDog
    {
        foreach (var dogCase in dogCases)
        {
            if (!dogCase.IsEmpty)
            {
                var dog = dogCase.Show();
                int satietyLevel = dog.SatietyLevel;

                dogCase.Fead(_feader);
                _loger.Log(StringFormater.СhangingParameter($"{dog.Name} уровень сытости", satietyLevel, dog.SatietyLevel));
            }
        }
    }

    private void InspectionDogs<T>(IList<DogCase<T>> dogCases) where T : class, IDog
    {
        List<T> illDogs = new List<T>();

        foreach (var dogCase in dogCases)
        {
            if (!dogCase.IsEmpty)
            {
                var dog = dogCase.Show();

                _loger.Log(dog.ToString());

                if (!_veterinarian.InspectDog(dog))
                {
                    illDogs.Add(dogCase.GetDog());
                }
            }
        }

        // лечение собак
        CureDogse(dogCases, illDogs);
    }

    private void CureDogse<T>(IList<DogCase<T>> dogCases, List<T> illDogs) where T : class, IDog
    {
        if (illDogs.Count > 0)
        {
            _loger.Log("Лечение собак:");

            foreach (var dog in illDogs)
            {
                int helthLevel = dog.HelthLevel;
                _veterinarian.Cure(dog);
                _loger.Log(StringFormater.СhangingParameter($"Лечение собаки {dog.Name}", helthLevel, dog.HelthLevel));
            }

            PutDogsToCase(illDogs, dogCases);
        }
    }

    private void CleaningCase<T>(IList<DogCase<T>> dogCases) where T : class, IDog
    {
        foreach (var dogCase in dogCases)
        {
            dogCase.Clean();
        }
    }

    private void Training()
    {
        List<Puppy> puppys = new();

        foreach (var puppy in _puppys)
        {
            var pup = puppy.GetDog();

            if (pup != null)
            {
                if (pup.HelthLevel >= IDog.MIN_HELTHY_NORMA)
                {
                    puppys.Add(pup);
                }
                else
                {
                    puppy.SetDog(pup);
                }
            }
        }

        _loger.Log(_trainingPark.Train(puppys));

        PutDogsToCase(puppys, _puppys);
    }

    private void Working()
    {
        List<AdultDog> unemployedAdultDog = new List<AdultDog>();

        foreach (var dogCase in _adultDogs)
        {
            if (!dogCase.IsEmpty)
            {
                var adultDog = dogCase.GetDog();

                if (!adultDog.ReadyToWork || !_workPlaces.PutToWork(adultDog))
                {
                    unemployedAdultDog.Add(adultDog);
                    dogCase.SetDog(adultDog);
                }
            }
        }

        StringBuilder builder = new StringBuilder("Безработные собаки (и те кто не смог сегодня работать):\n");

        foreach (var unemploed in unemployedAdultDog)
        {
            builder.AppendLine(unemploed.DoWork());
        }

        _loger.Log(builder.ToString());

        var workPlaces = _workPlaces.GetAllWorkPlaces();

        foreach (var work in workPlaces)
        {
            _loger.Log(work.SimulateWorkingDay());
        }

        List<AdultDog> workted = new(_adultDogs.Count);

        foreach (var workPlace in workPlaces)
        {
            var workersFromWork = workPlace.GetWorkers();
            
            workPlace.CloseWorkPlace();

            workted.AddRange(workersFromWork);
        }

        PutDogsToCase(workted, _adultDogs);
    }

    private void Existing()
    {
        var sb = new StringBuilder();

        foreach (var oldDog in _oldDogs)
        {
            if (!oldDog.IsEmpty)
            {
                sb.AppendLine(oldDog.Show().Existe());
            }
        }

        _loger.Log("Жизнь старых собак");
        _loger.Log(sb.ToString());
    }

    public void Add(IList<Puppy> puppies)
    {
        Add(_puppys, puppies);
    }

    public void Add(IList<AdultDog> adultDogs)
    {
        Add(_adultDogs, adultDogs);
    }

    public void Add(IList<OldDog> oldDogs)
    {
        Add(_oldDogs, oldDogs);
    }

    private void Add<T>(IList<DogCase<T>> cases, IList<T> coll) where T: class, IDog
    {
        foreach (T dog in coll)
        {
            cases.Add(new DogCase<T>(dog));
            _indexes.Add(dog.ID, cases.Count - 1);
        }
    }

    private void PutDogsToCase<T>(IList<T> dogs, IList<DogCase<T>> dogCases) where T: class, IDog
    {
        for (int i = 0; i < dogs.Count; i++)
        {
            dogCases[_indexes[dogs[i].ID]].SetDog(dogs[i]);
        }
    }
}
