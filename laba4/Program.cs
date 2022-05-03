using laba4.FarmDogs;
using laba4.FarmDogs.Veterinarians;
using laba4.Generators;
using laba4.Logers;
using laba4.PlaceOfWork;
using laba4.ProfessionManegers;
using laba4.WorkPlaceManeger;

ILoger loger = new ConsoleLoger();

IAdultFactoryManeger workerProducer = new RandomAdultFactoryManeger();

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

loger.Close();