namespace UniDialog.Domain
{

    public class MenuDialogFrameModel: IDialogFrame
    {
        public string Title { get; set;}

        public IDialog Owner { get; set; }
    }

}
