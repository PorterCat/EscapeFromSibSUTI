namespace EscapeFromSibSUTI.script.Enums;

public enum SceneType
{
    Menu,
    CharacterCreation,
    Game,
    Info,
    Exit,
}

public static partial class EnumExtensions
{
    private static Dictionary<SceneType, string> _sceneTypes = new()
        {
            {SceneType.Menu, "Меню" },
            {SceneType.CharacterCreation, "Создание персонажа" },
            {SceneType.Game, "Играть"},
            {SceneType.Info, "Информация" },
            {SceneType.Exit, "Выход" }
        };

    public static string GetFriendlyName(this SceneType sceneType) => _sceneTypes[sceneType];
}
