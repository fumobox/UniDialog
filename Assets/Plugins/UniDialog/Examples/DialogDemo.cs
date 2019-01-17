using System.Collections.Generic;
using UniDialog.Domain;
using UnityEngine;
using UniDialog.Presentation;
using UniRx;
using UnityEngine.UI;

public class DialogDemo : MonoBehaviour
{

    [SerializeField] DialogRootPresenter _dialogRoot;

    [SerializeField] Button _confirmDialogButton;

    [SerializeField] Button _menuDialogButton;

    [SerializeField] Button _stackDialogButton;

    int n;

    void Start()
    {
        _confirmDialogButton.OnClickAsObservable().Subscribe(_ =>
        {
            var dialog = new ConfirmDialog("Are you ok?", ConfirmDialogSize.Minimum);
            dialog.Stackable = false;
            _dialogRoot.Enqueue(dialog);
        }).AddTo(this);

        _menuDialogButton.OnClickAsObservable().Subscribe(_ =>
        {
            var content = new MenuDialogContentModel();
            content.MenuItems.Add(new MenuDialogItemModel("apple", "Apple"));
            content.MenuItems.Add(new MenuDialogItemModel("banana", "Banana"));
            content.MenuItems.Add(new MenuDialogItemModel("tomato", "Tomato"));

            var dialog = new MenuDialog("Menu", content);
            dialog.OnClickAsObservable().Subscribe(b =>
            {
                _dialogRoot.Enqueue(new ConfirmDialog(b.Name, ConfirmDialogSize.Minimum));
                dialog.Close();
            }).AddTo(this);

            _dialogRoot.Enqueue(dialog);
        }).AddTo(this);

        _stackDialogButton.OnClickAsObservable().Subscribe(_ =>
        {
            n = 0;
            AddDialog(n++, true);
        }).AddTo(this);
    }

    void AddDialog(int id, bool stackable)
    {
        var buttons = new List<IDialogButton>();
        buttons.Add(new ConfirmDialogButton("add", "Enqueue"));
        buttons.Add(new ConfirmDialogButton("stack", "Overlay"));
        buttons.Add(new ConfirmDialogButton("close", "Close"));

        var dialog = new ConfirmDialog("Dialog " + id + (stackable ? "(Stackable)": ""), buttons, ConfirmDialogSize.Small);
        dialog.OnClickAsObservable().Subscribe(b =>
        {
            switch(b.Id)
            {
                case "add":
                    AddDialog(n++, false);
                    break;
                case "stack":
                    AddDialog(n++, true);
                    break;
                case "close":
                    dialog.Close();
                    break;
            }
        }).AddTo(this);
        dialog.Stackable = stackable;

        _dialogRoot.Enqueue(dialog);
    }
}
