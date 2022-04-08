namespace laba4.Professions;

public class RescueServiceDog : Profession
{
    // Паттерн синглтон
    private static RescueServiceDog? _instance = null;

    private RescueServiceDog() : base("Cобака спасательной службы") { }

    // паттерн ленивая инициализация
    public static Profession Instens => _instance ??= new RescueServiceDog();
}