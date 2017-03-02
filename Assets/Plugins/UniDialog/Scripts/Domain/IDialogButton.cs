using System.Collections;
using System;
using UniRx;

namespace UniDialog.Domain
{

    public interface IDialogButton
    {
        string Name { get; set;}

        Subject<IDialog> ClickStream { get; set;}

    }

}
