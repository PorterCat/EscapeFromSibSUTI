using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Modules;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

public class MainMenuScene : IScene 
{
    public void ShowScene(out SceneType returnScene)
    {
        Console.WriteLine("Главное меню: \n");
        returnScene = default;
        returnScene = (SceneType)Render.SelectFromEnum(returnScene);
    }
}
