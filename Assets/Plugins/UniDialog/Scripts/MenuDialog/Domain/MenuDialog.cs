using System;
using UniRx;

namespace UniDialog.Domain
{

    public class MenuDialog : IDialog
    {
        public DialogState State { get; set; }

        public bool Stackable { get; set; }

        public bool CloseOnTouchOutside { get; set; }

        public IDialogFrame Frame { get; set; }

        public IDialogContent Content { get; set; }

        Subject<IDialogButton> _clickStream;

        public string TemplateName
        {
            get
            {
                return "Menu";
            }
        }

        public MenuDialog(string title, IDialogContent contentModel)
        {
            var frame = new MenuDialogFrameModel();
            frame.Title = title;
            Frame = frame;
            frame.Owner = this;

            Content = contentModel;
            contentModel.Owner = this;

            CloseOnTouchOutside = true;

            _clickStream = new Subject<IDialogButton>();
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
