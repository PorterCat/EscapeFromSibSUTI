namespace EscapeFromSibSUTI.script.Enums;

public enum MenuPoint
{
    NewGame,
    LoadCharacter,
    Info,
    Exit
}

public static partial class EnumExtensions
{
    private static Dictionary<MenuPoint, string> _menuPoints = new()
        {
            { MenuPoint.NewGame, "Новая игра" },
            { MenuPoint.LoadCharacter, "Загрузить персонажа" },
            { MenuPoint.Info, "Информация" },
            { MenuPoint.Exit, "Выход" }
        };

    public static string GetFriendlyName(this MenuPoint menuPoint) => _menuPoints[menuPoint];
}
