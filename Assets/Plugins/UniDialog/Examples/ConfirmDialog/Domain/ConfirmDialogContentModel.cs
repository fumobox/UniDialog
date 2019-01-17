namespace UniDialog.Domain
{

    public class ConfirmDialogContentModel: IDialogContent
    {
        public string Text { get; set;}

        public IDialog Owner { get; set; }

    }

}
