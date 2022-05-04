using System.ComponentModel;

namespace ClearMeasure.Palermo.Core;

public static class EnumExtensions
{
    public static string ToDescriptionString<T>(this T val) where T : System.Enum
    {
        var flagAttributes = (FlagsAttribute[])val.GetType()
            .GetCustomAttributes(typeof(FlagsAttribute), false);
        if (flagAttributes.Length > 0)
        {
            return GetCombinedDescription(val);
        }
        return GetDescription(val);
    }

    private static string GetCombinedDescription<TEnum>(TEnum val) where TEnum : System.Enum
    {
        var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        if (values.Any(v => (int)(object)v == 0))
        {
            var zeroVal = values.Single(v => (int)(object)v == 0);
            if ((int)(object)val == (int)(object)zeroVal)
            {
                return GetDescription(zeroVal);
            }

            values = values.Where(v => (int)(object)v != 0);
        }

        var splitVal = values.Where(v => val.HasFlag(v));
        var descriptions = splitVal.Select(v => GetDescription(v));
        return string.Join(", ", descriptions);
    }
    private static string GetDescription<T>(T val) where T : System.Enum
    {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])val
            .GetType()
            .GetField(val.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
}
