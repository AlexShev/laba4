namespace laba4.StringFormaters;

public class StringFormater
{
    public static string СhangingParameter<T>(string purametername, T oldParameterValue, T newParameterValue)
    {
        return $"{purametername}: {oldParameterValue} -> {newParameterValue}";
    }
}
