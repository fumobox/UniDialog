using System.Collections.Generic;
using System;
using UniRx;
using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Preset.Confirm.Domain
{
    public class ConfirmDialogButton: IDialogButton
    {
        public string Name { get; set;}

        public Subject<IDialog> ClickStream { get; set;}

        public ConfirmDialogButton(string name, bool clickOnClose = false)
        {
            Name = name;

            ClickStream = new Subject<IDialog>();

            if (clickOnClose)
            {
                ClickStream.Subscribe(dialog => dialog.Close());
            }
        }

    }

}
