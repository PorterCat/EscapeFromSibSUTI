using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Scenes;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script;

public class Game
{
    private IScene _currentScene;
    private SceneType _currentSceneType = SceneType.Menu;
    private Character _player = new();

    public void StartGame()
    {
        while (true)
        {
            switch (_currentSceneType)
            {
                case SceneType.Menu:
                    Console.Clear();
                    _currentScene = new MainMenuScene();
                    _currentScene.ShowScene(out _currentSceneType);
                    break;

                case SceneType.CharacterCreation:
                    Console.Clear();
                    _currentScene = new CreatingCharacterScene(_player);
                    _currentScene.ShowScene(out _currentSceneType);
                    break;
                case SceneType.Game:
                    Console.Clear();
                    _currentScene = new GameScene(_player);
                    _currentScene.ShowScene(out _currentSceneType);
                    break;

                case SceneType.Exit:
                    return;
            }
        }
    }
}
