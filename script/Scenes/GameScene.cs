using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

internal class GameScene : IScene
{
    private Character _character;

    public GameScene(Character character)
    {
        _character = character;
    }

    public void ShowScene(out Enums.SceneType returnScene)
    {
        returnScene = Enums.SceneType.Menu;
        Console.Clear();
        Console.WriteLine($"{_character.Name} готов подать свои документы в СибГУТИ?");
        Console.ReadLine();
    }
}
