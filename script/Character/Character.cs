using EscapeFromSibSUTI.script.Enums;

namespace EscapeFromSibSUTI.script;

public class Character
{
    public Character() { }

    public string Name { get; set; }
    public string Description { get; set; }
    public int HealthPoint { get; set; }
    public int Stamina { get; set; }
    public int Level { get; private set; }
    public Gender? Gender { get; set; }
    public Fraction? Fraction { get; set; }
    public Dictionary<Characterstic, int> Characterstic { get; set; }
}
