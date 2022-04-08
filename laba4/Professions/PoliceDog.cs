namespace laba4.Professions;

public class PoliceDog : Profession
{
    // Паттерн синглтон
    private static PoliceDog? _instance = null;

    private PoliceDog() : base("Полицейская собака") { }

    // паттерн ленивая инициализация
    public static Profession Instens => _instance ??= new PoliceDog();
}
