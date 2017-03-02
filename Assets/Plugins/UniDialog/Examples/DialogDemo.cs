using UnityEngine;
using System.Collections;
using UniDialog;
using UniDialog.Preset.Confirm.Domain;
using UniRx;
using UniDialog.Domain;
using System.Collections.Generic;
using UniDialog.Presentation;

public class DialogDemo : MonoBehaviour
{

    [SerializeField]
    Transform _dialogContainer = null;

    DialogQueueModel queue;

    void Start () {
        queue = DialogBuilder.CreateQueue(_dialogContainer);
        ShowDialog("First Dialog");
    }

    void ShowDialog(string title)
    {
        var okButton = new ConfirmDialogButton("OK");
        okButton.ClickStream.Subscribe(d =>
            {
                d.Close();
                ShowDialog("Dialog: " + Random.Range(0, 999));
            }).AddTo(this);

        var cancelButton = new ConfirmDialogButton("Cancel");
        cancelButton.ClickStream.Subscribe(d =>
            {
                d.Close();
                ShowDialog("Dialog: " + Random.Range(0, 999));
            }).AddTo(this);

        var dialog = new ConfirmDialog(title, new List<IDialogButton> { okButton, cancelButton }, ConfirmDialogSize.Minimum);
        dialog.CloseOnTouchOutside = false;

        queue.Enqueue(dialog);
    }

}
