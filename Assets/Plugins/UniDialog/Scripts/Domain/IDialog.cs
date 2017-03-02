using System;
using System.Collections.Generic;
using UniRx;

namespace UniDialog.Domain
{
    public enum DialogState
    {
        Closed, Opening, Opened, Closing
    }

    public interface IDialog
    {
        DialogState State { get; set;}

        bool Stackable { get; set;}

        bool CloseOnTouchOutside { get; set;}

        string PresenterPath { get;}

        IDialogFrame Frame { get; set;}

        IDialogContent Content { get; set;}

        void Open();

        void Close();
    }

}
