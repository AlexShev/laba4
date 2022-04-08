// See https://aka.ms/new-console-template for more information


//DateTime _date = DateTime.Parse("6.4.2000");

//Console.WriteLine((int)((DateTime.Today.Subtract(_date).TotalDays + 1) / 365.2425));

using laba4;
using laba4.Decorators;
using laba4.FarmDogs;
using laba4.FarmDogs.Veterinarians;
using laba4.Generators;
using laba4.Logers;
using laba4.PlaceOfWork;
using laba4.ProfessionManegers;
using laba4.WorkPlaceManeger;

ILoger loger = new FileLoger();

//new FarmDog(
//    new List<Puppy>() { new Puppy("хз", DateTime.Now) },
//    new List<AdultDog>() { new PoliceDog(new Puppy("хз1", DateTime.Now.AddYears(-2))) },
//    new List<OldDog>() { new OldDog(new RescueServiceDog(new Puppy("хз3", DateTime.Now.AddYears(-9)))) },
//    new WorkPlaceManeger(new List<WorkPlace>() { new Police(), new RescueService() }),
//    new Feader(),
//    new TrainingPark(),
//    new SimpleVeterinarian(),
//    loger
//).SimulateDay();

IWorkerProducerManeger<Puppy, AdultDog> workerProducer = new RandomWorkerCreater();

DogGenerator dogGenerator = new DogGenerator(workerProducer);

new FarmDog(
    dogGenerator.GeneratePuppys(10),
    dogGenerator.GenereteAdultDogs(10),
    dogGenerator.GenereteOldDogs(10),
    new WorkPlaceManeger(new List<WorkPlace>() { new Police(), new RescueService() }),
    new Feader(),
    new TrainingPark(),
    new SimpleVeterinarian(),
    loger
).SimulateDay();

// loger.Close();