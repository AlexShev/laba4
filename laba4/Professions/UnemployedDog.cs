namespace laba4.Professions;

public class UnemployedDog : Profession
{
    // Паттерн синглтон
    private static UnemployedDog? _instance = null;

    private UnemployedDog() : base("Безработная") { }

    // паттерн ленивая инициализация
    public static Profession Instens => _instance ??= new UnemployedDog();
}
