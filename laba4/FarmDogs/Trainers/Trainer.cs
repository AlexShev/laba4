namespace laba4.FarmDogs;

public class Trainer : ITrainer
{
    private const int TRAINING_SCORE = 5;

    public bool Train(Puppy puppy)
    {
        return puppy.Training(TRAINING_SCORE);
    }
}
