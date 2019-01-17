using System;
using UniRx;
using System.Collections.Generic;

namespace UniDialog.Domain
{

    public class DialogQueueModel
    {
        Queue<IDialog> _queue= new Queue<IDialog>();

        Subject<IDialog> _onEnqueue = new Subject<IDialog>();

        public List<IDialog> ActiveDialogs { get; private set;}

        public IReadOnlyReactiveProperty<bool> Locked
        {
            get { return _locked; }
        }

        BoolReactiveProperty _locked = new BoolReactiveProperty();

        public DialogQueueModel()
        {
            ActiveDialogs = new List<IDialog>();
        }

        public void Enqueue(IDialog dialog)
        {
            _queue.Enqueue(dialog);
            _onEnqueue.OnNext(dialog);
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

        public void CloseAllDialogs(bool clearQueue = false)
        {
            ActiveDialogs.ForEach(d => d.Close());
            if(clearQueue)
                _queue.Clear();
        }

        public IObservable<IDialog> OnEnqueueAsObservable()
        {
            return _onEnqueue.AsObservable();
        }

        public void Lock()
        {
            _locked.Value = true;
        }

        public void Unlock()
        {
            _locked.Value = false;
        }

    }

}
