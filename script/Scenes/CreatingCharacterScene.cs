using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Modules;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

internal class CreatingCharacterScene : IScene
{
    private Character _character;

    public CreatingCharacterScene(Character character)
    {
        _character = character;
    }

    public void ShowScene(out SceneType returnScene)
    {
        returnScene = default;
        int row = Console.CursorTop;
        int col = Console.CursorLeft;
        int index = 0;


        CharacterCreationPoint selectedPoint = default;
        while(true) 
        {
            selectedPoint = (CharacterCreationPoint)Render.SelectFromEnum(selectedPoint, () => DrawMenu(row, col, index));
            switch (selectedPoint)
            {
                case CharacterCreationPoint.Name:
                    ChooseName();
                    break;

                case CharacterCreationPoint.Fraction:
                    ChooseFraction(row, col);
                    break;

                case CharacterCreationPoint.Description:
                    break;

                case CharacterCreationPoint.Gender:
                    ChooseGender();
                    break;

                case CharacterCreationPoint.Сharacteristic:
                    break;

                case CharacterCreationPoint.Play:
                    returnScene = SceneType.Game;
                    return;

                case CharacterCreationPoint.BackToMenu:
                    returnScene = SceneType.Menu;
                    return;
            }
            Console.Clear();
        }
    }

    private void DrawMenu(int row, int col, int index)
    {
        Console.SetCursorPosition(col, row++);
        Console.WriteLine("Меню создания персонажа:");
        Console.SetCursorPosition(Console.WindowWidth / 2 + 2, 0);
        Console.WriteLine("Персонаж:");
        for (int i = 0; i < 25; i++)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, i);
            Console.Write('╫');
        }

        Console.SetCursorPosition(Console.WindowWidth / 2 + 2, row++);
        if (_character.Name != null)
        {
            Console.WriteLine($"Имя: {_character.Name}");
        }
        Console.SetCursorPosition(Console.WindowWidth / 2 + 2, row++);
        if (_character.Fraction != null)
        {
            Console.WriteLine($"Фракция: {_character.Fraction.GetFriendlyName()}");
        }
        Console.SetCursorPosition(Console.WindowWidth / 2 + 2, row++);
        if (_character.Gender != null)
        {
            Console.WriteLine($"Пол: {_character.Gender.GetFriendlyName()}");
        }

        Console.SetCursorPosition(col, row = 1);
        
        Console.WriteLine();
    }

    private void DrawFraction(List<Fraction> items, int row, int col, int index)
    {
        Console.Clear();
        Console.SetCursorPosition(col, row);
        Console.WriteLine("Меню создания персонажа:");

        Console.SetCursorPosition(25, row);
        switch (items[index])
        {
            case Fraction.IP:
                Console.Write("Добро пожаловать в удивительный мир фракции \"групп ИП\" университета \"СибГУТИ\"\n");
                Console.SetCursorPosition(25, ++row);
                Console.Write("Эта самая многочисленная группа информатиков, занимающиеся программированием, — настоящие герои цифровой эпохи! \n");
                Console.Write("\n");
                break;
            case Fraction.IV:
                Console.Write("Добро пожаловать в удивительный мир фракции \"групп ИВ\" университета \"СибГУТИ\"\n");
                Console.SetCursorPosition(25, ++row);
                Console.Write("Если бы у нас была книга заклинаний, они бы владели всеми уровнями Wi-Fi!");
                Console.SetCursorPosition(25, ++row);
                Console.Write("Сетевые админы могут создать связь даже в самых отдаленных и магических уголках института.\n");
                Console.Write("\n");
                break;
            case Fraction.IA:
                Console.Write("Добро пожаловать в удивительный мир фракции \"групп ИА\" университета \"СибГУТИ\"\n");
                Console.SetCursorPosition(25, ++row);
                Console.Write("Не бойся, мы всего лишь рефакторим этот MVP в MVVM с использованием Kotlin!\n");
                Console.Write("\n");
                break;

        }

        Console.SetCursorPosition(col, 1);
        for (int i = 0; i < items.Count; i++)
        {
            if (i == index)
            {
                Console.BackgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            string output;
            switch (items[i])
            {
                case Fraction.IP:
                    output = "Играть за ИПшников";
                    break;
                case Fraction.IV:
                    output = "Играть за ИВшников";
                    break;
                case Fraction.IA:
                    output = "Играть за ИАшников";
                    break;
                default:
                    output = "Чёт багануло";
                    break;
            }
            Console.WriteLine(output);
            Console.ResetColor();
        }
        Console.WriteLine();
    }

    private void ChooseName()
    {
        Console.Clear();
        Console.WriteLine("Введите имя персонажа");
        string name = Console.ReadLine();
        _character.Name = name;
        Console.Clear();
    }

    private void ChooseGender()
    {
        Console.Clear();
        Console.WriteLine("Выберите гендер:");

        Dictionary<int, string> menuPoints = new Dictionary<int, string>
        {
            { 0, "Студент" },
            { 1, "Студентка" },
            { 2, "Выход" }
        };

        int index = 0;

        while (true)
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
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch (index)
                    {
                        case 0:
                            _character.Gender = Gender.Male;
                            return;

                        case 1:
                            _character.Gender = Gender.Female;
                            return;
                        case 2:
                            return;

                        default:
                            Console.WriteLine($"Выбран пункт {menuPoints[index]}");

                            break;
                    }
                    break;
            }

        }
    }

    private void ChooseFraction(int row, int col)
    {
        List<Fraction> fractions = new List<Fraction>()
                                {
                                    Fraction.IP,
                                    Fraction.IV,
                                    Fraction.IA,
                                };
        Console.Clear();
        Console.WriteLine("Выберите фракцию");

        int index = 0;

        while (true)
        {
            DrawFraction(fractions, row, col, index);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < fractions.Count - 1)
                    {
                        index++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                    {
                        index--;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch (index) //Логика переходов
                    {
                        case 0:
                            _character.Fraction = Fraction.IP;
                            return;

                        case 1:
                            _character.Fraction = Fraction.IV;
                            return;

                        case 2:
                            _character.Fraction = Fraction.IA;
                            return;
                        case 3:
                            return;
                    }
                    break;
            }
        }
    }
}
