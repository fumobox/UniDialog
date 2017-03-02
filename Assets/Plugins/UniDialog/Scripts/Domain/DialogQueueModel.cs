using System.Collections;
using System;
using UniRx;
using System.Collections.Generic;

namespace UniDialog.Domain
{

    public class DialogQueueModel
    {
        Queue<IDialog> _queue;

        Subject<IDialog> _dialogStream;

        public List<IDialog> ActiveDialogs { get; private set;}

        public bool Locked { get; set;}

        public DialogQueueModel()
        {
            _queue = new Queue<IDialog>();
            _dialogStream = new Subject<IDialog>();
            ActiveDialogs = new List<IDialog>();
        }

        public void Enqueue(IDialog dialog)
        {
            _queue.Enqueue(dialog);
            _dialogStream.OnNext(dialog);
        }

        public IDialog Dequeue()
        {
            return _queue.Dequeue();
        }

        public int QueueCount
        {
            get
            {
                return _queue.Count;
            }
        }

        public bool IsAnyDialogActive
        {
            get
            {
                return ActiveDialogs.Count != 0;
            }
        }

        public void CloseAllDialog(bool clearQueue = false)
        {
            ActiveDialogs.ForEach(d => d.Close());
            if(clearQueue)
                _queue.Clear();
        }

        public IObservable<IDialog> OnEnqueueAsObservable()
        {
            return _dialogStream.AsObservable();
        }

    }

}
