using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

public class MainMenuScene : IScene 
{
    public void ShowScene(out SceneType returnScene)
    {
        Console.WriteLine("Главное меню: \n");

        Dictionary<int, string> menuPoints = new Dictionary<int, string>
        {
            { 0, "Новая игра" },
            { 1, "Загрузить персонажа" },
            { 2, "Информация" },
            { 3, "Выход" }
        };

        int index = 0;

        while(true)
        {
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < menuPoints.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(menuPoints[i]);
                Console.ResetColor();
            }
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < menuPoints.Count - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = menuPoints.Count - index - 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = menuPoints.Count - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch (index)
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
                            Console.WriteLine($"Выбран пункт {menuPoints[index]}");

                            break;
                    }
                    break;
            }
        }
    }
}
