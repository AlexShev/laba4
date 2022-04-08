using laba4.StringFormaters;
using System.Text;

namespace laba4.FarmDogs;

public class TrainingPark
{
    public ITrainer Trainer { get; set; } = new Trainer();

    public string Train(IList<Puppy> puppies)
    {
        StringBuilder sb = new();
        sb.AppendLine("Тренеровка собак:");

        foreach (Puppy puppy in puppies)
        {
            int trainingLevel = puppy.TrainingLevel;
            Trainer.Train(puppy);
            sb.AppendLine(StringFormater.СhangingParameter($"{puppy.Name}", trainingLevel, puppy.TrainingLevel));
        }

        return sb.ToString();
    }
}
