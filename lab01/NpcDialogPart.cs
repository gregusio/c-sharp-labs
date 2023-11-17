namespace SimpleGame;

public class NpcDialogPart : IDialogPart
{
    private readonly string _content;
    public readonly List<HeroDialogPart>? HeroAnswers;

    public NpcDialogPart(string content, List<HeroDialogPart>? heroAnswers)
    {
        _content = content;
        HeroAnswers = heroAnswers;
    }

    public string GetDialog()
    {
        return _content;
    }
}