using System;

namespace UniDialog.Domain
{
    public interface IDialog
    {
        DialogState State { get; set;}

        bool Stackable { get; set;}

        bool CloseOnTouchOutside { get; set;}

        string TemplateName { get;}

        IDialogFrame Frame { get; set;}

        IDialogContent Content { get; set;}

        void Open();

        void Close();

        void Click(IDialogButton button);

        IObservable<IDialogButton> OnClickAsObservable();
    }

}
