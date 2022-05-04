namespace ClearMeasure.Palermo.Core;

public class EnumOptionValue<T> where T : System.Enum
{
    public string Name { get; set; }
    public T Value { get; set; }

    public static List<EnumOptionValue<T>> GetValues()
    {
        return Enum.GetNames(enumType: typeof(T)).Select(l =>
        {
            var type = (T)Enum.Parse(typeof(T), l);
            return new EnumOptionValue<T> { Name = type.ToDescriptionString(), Value = type };
        }).ToList();
    }
}