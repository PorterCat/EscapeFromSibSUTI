namespace EscapeFromSibSUTI.script.Enums;

public enum Gender
{
    Male, 
    Female
}

public static partial class EnumExtensions
{
    private static Dictionary<Gender, string> _genders = new()
        {
            { Gender.Male, "Студент" },
            { Gender.Female, "Студентка"}
        };

    public static string GetFriendlyName(this Gender gender) => _genders[gender];
}