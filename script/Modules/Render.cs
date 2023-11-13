using EscapeFromSibSUTI.script.Enums;

namespace EscapeFromSibSUTI.script.Modules;

public static class Render
{
    public static Action IndexChanged;
    private static int _index;
    public static int Index
    { 
        get => _index;
        private set 
        {
            _index = value;
            IndexChanged?.Invoke();
        }
    }

    public static Enum SelectFromEnum(Enum someEnum, Action? callback = null)
    {
        var enumValues =  someEnum.ExtractFromEnum();
        Index = 0;

        while (true)
        {
            callback?.Invoke();
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < enumValues.Length; i++)
            {
                if (i == Index)
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
                    if (Index < enumValues.Length - 1)
                    {
                        Index++;
                    }
                    else
                    {
                        Index = enumValues.Length - Index - 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Index > 0)
                    {
                        Index--;
                    }
                    else
                    {
                        Index = enumValues.Length - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    return someEnum.SetValue(Index);
            }
        }
    }
}
