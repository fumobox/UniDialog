using System;
using System.Collections.Generic;
using UniRx;

namespace UniDialog.Domain
{
    public class ConfirmDialog: IDialog
    {
        public DialogState State { get; set;}

        public bool Stackable { get; set;}

        public bool CloseOnTouchOutside { get; set;}

        public IDialogFrame Frame { get; set;}

        public IDialogContent Content { get; set;}

        public List<IDialogButton> Buttons { get; set;}

        Subject<IDialogButton> _clickStream = null;

        string _templateName;

        public string TemplateName
        {
            get
            {
                return _templateName;
            }
        }

        public ConfirmDialog(string title, ConfirmDialogSize size = ConfirmDialogSize.Medium)
            : this(title, new ConfirmDialogContentModel(), new List<IDialogButton>() { new ConfirmDialogButton("OK") }, size)
        {
            _clickStream.Subscribe(b =>
            {
                Close();
            });
        }

        public ConfirmDialog(string title, List<IDialogButton> buttons, ConfirmDialogSize size = ConfirmDialogSize.Medium)
            : this(title, new ConfirmDialogContentModel(), buttons, size)
        {
        }

        public ConfirmDialog(string title, IDialogContent contentModel, List<IDialogButton> buttons, ConfirmDialogSize size = ConfirmDialogSize.Medium, string templateName = "Confirm")
        {
            var frame = new ConfirmDialogFrameModel();
            frame.Size = size;
            frame.Title = title;
            Frame = frame;
            frame.Owner = this;

            Content = contentModel;
            contentModel.Owner = this;

            Buttons = buttons;

            CloseOnTouchOutside = true;

            _clickStream = new Subject<IDialogButton>();

            _templateName = templateName;
        }

        public ConfirmDialog(string title, string text, List<IDialogButton> buttons,
            ConfirmDialogSize size = ConfirmDialogSize.Medium)
            : this(title, new ConfirmDialogContentModel {Text = text}, buttons, size)
        {
        }

        public void Open()
        {
            State = DialogState.Opening;
        }

        public void Close()
        {
            State = DialogState.Closing;
            _clickStream.Dispose();
        }

        public IObservable<IDialogButton> OnClickAsObservable()
        {
            return _clickStream.Where(_ => State == DialogState.Opened).AsObservable();
        }

        public void Click(IDialogButton button)
        {
            _clickStream.OnNext(button);
        }

    }

}
