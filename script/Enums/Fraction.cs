namespace EscapeFromSibSUTI.script.Enums;

public enum Fraction
{
    IP, 
    IV, 
    IA,
}

public static partial class EnumExtensions
{
    private static Dictionary<Fraction, string> _fractions = new()
    {
        {Fraction.IP, "ИПшники"},
        {Fraction.IV, "ИВшники"},
        {Fraction.IA, "ИАшники"},
    };

    public static string GetFriendlyName(this Fraction point) => _fractions[point];
}