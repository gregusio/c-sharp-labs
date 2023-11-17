namespace SimpleGame;

public class NonPlayerCharacter
{
    public readonly string Name;
    public readonly NpcDialogPart Dialog;

    public NonPlayerCharacter(string name, NpcDialogPart dialog)
    {
        Name = name;
        Dialog = dialog;
    }
}