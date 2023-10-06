namespace EscapeFromSibSUTI.script.Enums;

public enum CharacterCreationPoint
{
    Name, 
    Fraction, 
    Description, 
    Gender,
    Сharacteristic,
    Play, 
    BackToMenu,
}

public static partial class EnumExtensions
{
    private static Dictionary<CharacterCreationPoint, string> _characterCreationPoints = new()
    {
        {CharacterCreationPoint.Name, "Выбрать имя"},
        {CharacterCreationPoint.Fraction, "Выбрать фракцию"},
        {CharacterCreationPoint.Description, "Написать описание"},
        {CharacterCreationPoint.Gender, "Выбрать пол"},
        {CharacterCreationPoint.Сharacteristic, "Выбрать характеристики"},
        {CharacterCreationPoint.Play, "Играть"},
        {CharacterCreationPoint.BackToMenu, "Назад в главное меню"},
    };

    public static string GetFriendlyName(this CharacterCreationPoint point) => _characterCreationPoints[point]; 
}
