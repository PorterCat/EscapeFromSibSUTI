using EscapeFromSibSUTI.script.Enums;

namespace EscapeFromSibSUTI.script.Modules;

public static class Render
{
    public static Enum SelectFromEnum(Enum someEnum, Action callback = null)
    {
        var enumValues =  someEnum.ExtractFromEnum();
        int index = 0;

        while (true)
        {
            callback?.Invoke();
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < enumValues.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                };
                Console.WriteLine(someEnum.SetValue(i).GetFriendlyName());
                Console.ResetColor();
            }
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < enumValues.Length - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = enumValues.Length - index - 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = enumValues.Length - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    return someEnum.SetValue(index);
            }
        }
    }
}
