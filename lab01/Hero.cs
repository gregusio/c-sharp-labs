namespace SimpleGame;

public class Hero
{
    public readonly string Name;
    public readonly EHeroClass HeroClass;

    public Hero(string name, EHeroClass heroClass)
    {
        Name = name;
        HeroClass = heroClass;
    }
}