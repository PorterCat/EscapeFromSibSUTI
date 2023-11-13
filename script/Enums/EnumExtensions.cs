namespace EscapeFromSibSUTI.script.Enums;

public static class EnumExtensions
{
    private static Dictionary<CharacterCreationPoint, string> _characterCreationPoints = new()
    {
        {CharacterCreationPoint.Name, "Выбрать имя"},
        {CharacterCreationPoint.Fraction, "Выбрать фракцию"},
        {CharacterCreationPoint.Description, "Написать описание"},
        {CharacterCreationPoint.Gender, "Выбрать пол"},
        {CharacterCreationPoint.Сharacteristic, "Выбрать характеристики"},
        {CharacterCreationPoint.Play, "Играть"},
        {CharacterCreationPoint.BackToMenu, "Назад в главное меню"},
    };

    private static Dictionary<Fraction, string> _fractions = new()
    {
        {Fraction.IP, "ИПшники"},
        {Fraction.IV, "ИВшники"},
        {Fraction.IA, "ИАшники"},
    };

    private static Dictionary<Gender, string> _genders = new()
    {
        { Gender.Male, "Студент" },
        { Gender.Female, "Студентка"}
    };

    private static Dictionary<MenuPoint, string> _menuPoints = new()
    {
        { MenuPoint.NewGame, "Новая игра" },
        { MenuPoint.LoadCharacter, "Загрузить персонажа" },
        { MenuPoint.Info, "Информация" },
        { MenuPoint.Exit, "Выход" }
    };

    private static Dictionary<SceneType, string> _sceneTypes = new()
    {
        {SceneType.Menu, "" },
        {SceneType.CharacterCreation, "Создание персонажа" },
        {SceneType.Game, "Играть"},
        {SceneType.Info, "Информация" },
        {SceneType.Exit, "Выход" }
    };

    public static string GetFriendlyName(this Enum thisEnum)
    {
        Type type = thisEnum.GetType();
        switch (type)
        {
            case var t when t == typeof(CharacterCreationPoint):
                return _characterCreationPoints[(CharacterCreationPoint)thisEnum];

            case var t when t == typeof(Fraction):
                return _fractions[(Fraction)thisEnum];

            case var t when t == typeof(Gender):
                return _genders[(Gender)thisEnum];

            case var t when t == typeof(MenuPoint):
                return _menuPoints[(MenuPoint)thisEnum];

            case var t when t == typeof(SceneType):
                return _sceneTypes[(SceneType)thisEnum];

            default:
                throw new NotImplementedException($"Не используй меня с {type} :)");
        }
    }

    public static Array ExtractFromEnum(this Enum thisEnum) => Enum.GetValues(thisEnum.GetType());

    // Обидно, что я живу в мире, где нельзя нормально
    // поменять значение переменной типа Enum
    public static Enum SetValue(this Enum thisEnum, int value)
    {
        Type type = thisEnum.GetType();
        switch (type)
        {
            case var t when t == typeof(CharacterCreationPoint):
                return (CharacterCreationPoint)value;

            case var t when t == typeof(Fraction):
                return (Fraction)value;

            case var t when t == typeof(Gender):
                return (Gender)value;

            case var t when t == typeof(MenuPoint):
                return (MenuPoint)value;

            case var t when t == typeof(SceneType):
                return (SceneType)value;

            default:
                throw new NotImplementedException($"Не используй меня с {type} :)");
        }
    }
}
