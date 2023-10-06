using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

public class MainMenuScene : IScene 
{
    public void ShowScene(out SceneType returnScene)
    {
        Console.WriteLine("Главное меню: \n");

        MenuPoint index = 0;
        int menuPointsCount = Enum.GetValues<MenuPoint>().Length;
        while (true)
        {
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < menuPointsCount; i++)
            {
                if (i == (int)index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                MenuPoint point = (MenuPoint)i;
                Console.WriteLine(point.GetFriendlyName());
                Console.ResetColor();
            }
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if ((int)index < menuPointsCount - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = menuPointsCount - index - 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = (MenuPoint)menuPointsCount - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch ((int)index)
                    {
                        case 0:
                            returnScene = SceneType.Game;
                            return;
                        case 1:
                            returnScene = SceneType.CharacterCreation;
                            return;
                        case 2: 
                            returnScene = SceneType.Info;
                            return;
                        case 3:
                            returnScene = SceneType.Exit;
                            return;
                        default:
                            break;
                    }
                    break;
            }
        }
    }
}
