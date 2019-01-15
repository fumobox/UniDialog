using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UniDialog.Domain;
using System.Linq;

namespace UniDialog.Presentation
{
    public class DialogRootPresenter : MonoBehaviour
    {
        [SerializeField]
        GameObject _dialogContainer;

        [SerializeField]
        GameObject _disabler;

        [SerializeField]
        List<DialogTemplate> _templates;

        DialogQueueModel _queue;

        public DialogQueueModel Queue
        {
            get { return _queue; }
        }

        void Awake()
        {
            _queue = new DialogQueueModel();

            _queue.OnEnqueueAsObservable().Subscribe(d =>
                {
                    Debug.Log("New Dialog: " + _queue.QueueCount);
                    Debug.Log("Locked: " + _queue.Locked);
                    UpdateQueue();
                }).AddTo(this);

            _queue.Locked.Subscribe(locked => _disabler.gameObject.SetActive(locked)).AddTo(this);
        }

        void UpdateQueue()
        {
            if (_queue.Locked.Value)
            {
                Debug.Log("Model is locked.");
                return;
            }

            if (_queue.QueueCount == 0)
            {
                Debug.Log("Queue is empty.");
                return;
            }

            if (_queue.ActiveDialogs.Count > 0)
            {
                if (!_queue.ActiveDialogs.Last().Stackable)
                {
                    Debug.Log("Active dialog is not stackable.");
                    return;
                }
            }

            var dialog = _queue.Dequeue();

            var template = FindTemplate(dialog.TemplateName);

            if (template == null)
            {
                Debug.LogError("Template not found: " + dialog.TemplateName + "\nPlease add templates on the dialog root.");
                return;
            }

            var presenter = Instantiate<DialogPresenter>(template.dialog, _dialogContainer.transform, false);
            presenter.Initialize(dialog, template);
            dialog.Open();

            dialog.ObserveEveryValueChanged(d => d.State).Subscribe(state =>
                {
                    switch (state)
                    {
                        case DialogState.Closed:
                            Destroy(presenter.gameObject);
                            _queue.Unlock();
                            _queue.ActiveDialogs.Remove(dialog);
                            UpdateQueue();
                            break;
                        case DialogState.Opening:
                            _queue.Lock();
                            break;
                        case DialogState.Opened:
                            _queue.Unlock();
                            _queue.ActiveDialogs.Add(dialog);
                            UpdateQueue();
                            break;
                        case DialogState.Closing:
                            _queue.Lock();
                            break;
                    }
                }).AddTo(presenter);
        }

        public DialogTemplate FindTemplate(string templateName)
        {
            foreach (var template in _templates)
            {
                if (template.templateName == templateName) return template;
            }
            return null;
        }

        public bool AddTemplate(DialogTemplate template)
        {
            if (FindTemplate(template.templateName) != null)
                return false;

            _templates.Add(template);
            return true;
        }

        public bool RemoveTemplate(string templateName)
        {
            var target = FindTemplate(templateName);

            if (target == null) return false;

            _templates.Remove(target);
            return true;
        }

        public void Enqueue(IDialog dialog)
        {
            _queue.Enqueue(dialog);
        }

    }
}
