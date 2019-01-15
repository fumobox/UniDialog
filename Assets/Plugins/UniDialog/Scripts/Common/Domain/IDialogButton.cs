namespace UniDialog.Domain
{
    public interface IDialogButton
    {
        string Id { get; set;}

        string Name { get; set;}

        IDialog Owner { get; set;}
    }
}
