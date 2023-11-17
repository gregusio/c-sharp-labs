namespace SimpleGame;

public class DialogParser
{
    private readonly Hero _hero;

    public DialogParser(Hero hero)
    {
        _hero = hero;
    }

    public string ParseDialog(IDialogPart dialog)
    {
        var name = "#HERONAME#";
        var dialogContent = dialog.GetDialog();
        if (dialogContent.Contains(name))
            return dialogContent.Replace(name, _hero.Name);

        return dialogContent;
    }
}