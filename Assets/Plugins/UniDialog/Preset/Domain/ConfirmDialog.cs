using System.Collections.Generic;
using UniDialog.Domain;

namespace UniDialog.Preset.Confirm.Domain
{
    public enum ConfirmDialogSize
    {
        Minimum, Small, Medium, Large
    }

    public class ConfirmDialog: IDialog
    {
        public DialogState State { get; set;}

        public bool Stackable { get; set;}

        public bool CloseOnTouchOutside { get; set;}

        public IDialogFrame Frame { get; set;}

        public IDialogContent Content { get; set;}

        public List<IDialogButton> Buttons { get; set;}

        public string PresenterPath
        {
            get
            {
                return "ConfirmDialogPrefab";
            }
        }

        public ConfirmDialog(string title, ConfirmDialogSize size = ConfirmDialogSize.Medium)
        {
            var frame = new ConfirmDialogFrameModel();
            frame.Size = size;
            Frame = frame;
            frame.Title = title;

            var contentModel = new ConfirmDialogContentModel();

            Content = contentModel;

            Buttons = new List<IDialogButton>() { new ConfirmDialogButton("OK", true) };

            CloseOnTouchOutside = true;
        }

        public ConfirmDialog(string title, List<IDialogButton> buttons, ConfirmDialogSize size = ConfirmDialogSize.Medium)
        {
            var frame = new ConfirmDialogFrameModel();
            frame.Size = size;
            frame.Title = title;
            Frame = frame;

            var contentModel = new ConfirmDialogContentModel();

            Content = contentModel;

            Buttons = buttons;

            CloseOnTouchOutside = true;
        }

        public ConfirmDialog(string title, IDialogContent contentModel, List<IDialogButton> buttons, ConfirmDialogSize size = ConfirmDialogSize.Medium)
        {
            var frame = new ConfirmDialogFrameModel();
            frame.Size = size;
            frame.Title = title;
            Frame = frame;

            Content = contentModel;

            Buttons = buttons;

            CloseOnTouchOutside = true;
        }

        public void Open()
        {
            State = DialogState.Opening;
        }

        public void Close()
        {
            State = DialogState.Closing;
        }

    }

}
