namespace SimpleGame;

public class HeroDialogPart : IDialogPart
{
    private readonly string _content;
    public readonly NpcDialogPart? NextDialog;

    public HeroDialogPart(string content, NpcDialogPart? nextDialog)
    {
        _content = content;
        NextDialog = nextDialog;
    }

    public string GetDialog()
    {
        return _content;
    }
}