namespace UniDialog.Domain
{

    public class ConfirmDialogFrameModel: IDialogFrame
    {
        public string Title { get; set;}

        public ConfirmDialogSize Size { get; set;}

        public IDialog Owner { get; set; }

    }

}
