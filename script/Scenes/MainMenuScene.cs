using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Modules;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

public class MainMenuScene : IScene 
{
    public void ShowScene(out SceneType returnScene)
    {
        Console.WriteLine("Главное меню:");
        returnScene = default;
        MenuPoint selectedPoint = default;
        while (true)
        {
            selectedPoint = (MenuPoint)Render.SelectFromEnum(selectedPoint);
            switch (selectedPoint)
            {
                case MenuPoint.NewGame:
                    returnScene = SceneType.Game;
                    return;

                case MenuPoint.LoadCharacter:
                    returnScene = SceneType.CharacterCreation;
                    return;

                case MenuPoint.Info:
                    returnScene = SceneType.Info;
                    return;

                case MenuPoint.Exit:
                    returnScene = SceneType.Exit;
                    return;
            }
            Console.Clear();
        }
    }
}
