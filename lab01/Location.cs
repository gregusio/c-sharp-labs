namespace SimpleGame;

public class Location
{
    public readonly string Name;
    public readonly List<NonPlayerCharacter> Npcs;

    public Location(string name, List<NonPlayerCharacter> npcs)
    {
        Name = name;
        Npcs = npcs;
    }
}