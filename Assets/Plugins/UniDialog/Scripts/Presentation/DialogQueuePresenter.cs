using UniRx;
using UnityEngine;
using UniDialog.Domain;
using System.Collections.Generic;
using Fumobox.Util;
using System.Linq;
using Fumobox.Presenter;

namespace UniDialog.Presentation
{
    public class DialogQueuePresenter : PresenterBehaviour<DialogQueueModel>
    {
        [SerializeField]
        GameObject _dialogContainer = null;

        [SerializeField]
        GameObject _lockPanel = null;

        DialogQueueModel _model;

        public override void Initialize(DialogQueueModel model)
        {
            _model = model;

            _model.OnEnqueueAsObservable().Subscribe(d =>
                {
                    Debug.Log("New Dialog: " + _model.QueueCount);
                    Debug.Log("Locked: " + _model.Locked);

                    UpdateQueue();
                }).AddTo(this);

            _model.ObserveEveryValueChanged(x => x.Locked).Subscribe(locked =>
                {
                    if (locked)
                    {
                        _lockPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        _lockPanel.gameObject.SetActive(false);
                    }
                });
        }

        void UpdateQueue()
        {
            if (_model.Locked)
            {
                Debug.Log("Model is locked.");
                return;
            }

            if (_model.QueueCount == 0)
            {
                Debug.Log("Queue is empty.");
                return;
            }

            if (_model.ActiveDialogs.Count > 0)
            {
                if (!_model.ActiveDialogs.Last().Stackable)
                {
                    Debug.Log("Active dialog is not stackable.");
                    return;
                }
            }

            var dialog = _model.Dequeue();

            var presenter = UnityTools.Instantiate<DialogPresenter>(dialog.PresenterPath, _dialogContainer.transform);
            presenter.Initialize(dialog);
            dialog.Open();

            dialog.ObserveEveryValueChanged(d => d.State).Subscribe(state =>
                {
                    switch (state)
                    {
                        case DialogState.Closed:
                            Debug.Log("Removed an active dialog.");
                            Destroy(presenter.gameObject);
                            _model.Locked = false;
                            _model.ActiveDialogs.Remove(dialog);
                            UpdateQueue();
                            break;
                        case DialogState.Opening:
                            _model.Locked = true;
                            break;
                        case DialogState.Opened:
                            _model.Locked = false;
                            _model.ActiveDialogs.Add(dialog);
                            UpdateQueue();
                            break;
                        case DialogState.Closing:
                            _model.Locked = true;
                            break;
                    }
                }).AddTo(presenter);
            
        }

    }
}
