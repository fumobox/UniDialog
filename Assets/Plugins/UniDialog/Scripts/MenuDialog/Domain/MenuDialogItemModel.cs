namespace UniDialog.Domain
{

    public class MenuDialogItemModel: IDialogButton
    {
        public string Id { get; set; }

        public string Name { get; set;}

        public object Subject { get; set;}

        public bool Disposed { get; private set;}

        public MenuDialogItemModel() : this("", "", null) { }

        public IDialog Owner { get; set; }

        public MenuDialogItemModel(string id, string text, object subject = null)
        {
            Id = id;
            Name = text;
            Subject = subject;
            Disposed = false;
        }

        public void Dispose()
        {
            Disposed = true;
        }

    }

}
