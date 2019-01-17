namespace UniDialog.Domain
{
    public interface IDialogFrame
    {
        string Title { get; set;}

        IDialog Owner { get; set; }
    }
}
