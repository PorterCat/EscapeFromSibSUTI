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
        CharacterCreationPoint selectedPoint = default;
        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Настройка персонажа:");
            selectedPoint = (CharacterCreationPoint)Render.SelectFromEnum(selectedPoint, () => ShowCharacterList());
            switch (selectedPoint)
            {
                case CharacterCreationPoint.Name:
                    ChooseName();
                    break;

                case CharacterCreationPoint.Fraction:
                    ChooseFraction();
                    break;

                case CharacterCreationPoint.Description:
                    /*ChooseDescription();*/
                    break;

                case CharacterCreationPoint.Gender:
                    ChooseGender();
                    break;

                case CharacterCreationPoint.Сharacteristic:
                    /*ChooseCharacteristic(); может тут тоже сделать отдельное окон?*/
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

    private void ShowCharacterList()
    {
        int row = 0, col = 40;

        Console.SetCursorPosition(col + 3, row);
        Console.Write("Лист персонажа:");
        row += 2;
        for (int i = 0; i < 8; i++)
        {
            Console.SetCursorPosition(col, row++);
            Console.Write("||");
        }

        Console.SetCursorPosition(col += 3, row = 2);
        if (_character.Name != null)
        {
            Console.Write($"Имя персонажа: {_character.Name}");
        }
        Console.SetCursorPosition(col, ++row);
        if (_character.Gender != null)
        {
            Console.Write($"Пол: {_character.Gender.GetFriendlyName()}");
        }
        Console.SetCursorPosition(col, ++row);
        if(_character.Fraction != null)
        {
            Console.Write($"Фракция: {_character.Fraction.GetFriendlyName()}");
        }
    }

    private void ShowFractionDescription(Fraction fraction)
    {
        int row = 7, col = 0;
        Console.SetCursorPosition(col, row);
        int padRight = 20;
        switch (fraction)
        {
            case Fraction.IP:
                Console.WriteLine("Ну тупа психи".PadRight(padRight)); break;
            case Fraction.IV:
                Console.WriteLine("Ещё психи".PadRight(padRight)); break;
            case Fraction.IA:
                Console.WriteLine("Третьи психи".PadRight(padRight)); break;
        }      
    }

    private void ChooseName()
    {
        Console.Clear();
        Console.WriteLine("Введите имя персонажа");
        ShowCharacterList();
        Console.SetCursorPosition(0, 1);
        _character.Name = Console.ReadLine();
    }

    private void ChooseGender()
    {
        Console.Clear();
        Console.WriteLine("Выберите пол");
        Gender selectedPoint = default;
        selectedPoint = (Gender)Render.SelectFromEnum(selectedPoint, () => ShowCharacterList());
        _character.Gender = selectedPoint;
    }

    private void ChooseFraction()
    {
        Console.Clear();
        Console.WriteLine("Выберите фракцию");
        Fraction selectedPoint = default;

        //подписка
        Render.IndexChanged += ShowDescription;
        selectedPoint = (Fraction)Render.SelectFromEnum(selectedPoint, () => ShowCharacterList());
        //отписка
        Render.IndexChanged -= ShowDescription;

        ShowFractionDescription(selectedPoint);
        _character.Fraction = selectedPoint;

        void ShowDescription() => ShowFractionDescription((Fraction)selectedPoint.SetValue(Render.Index));
    }


}
