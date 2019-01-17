using System;
using UniDialog.Domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniDialog.Presentation
{
    public class MenuDialogItemPresenter : MonoBehaviour
    {
        [SerializeField]
        Button _button;

        [SerializeField]
        Text _text;

        public MenuDialogItemModel Model { get; private set; }

        public string Text
        {
            get
            {
                return _text.text;
            }
            set
            {
                _text.text = value;
            }
        }

        public IObservable<Unit> OnClickAsObservable()
        {
            return _button.OnClickAsObservable();
        }

        public void Initialize(MenuDialogItemModel model)
        {
            Model = model;
            Text = model.Name;
            Model.ObserveEveryValueChanged(m => m.Disposed).Subscribe(f =>
            {
                if (f)
                {
                    Destroy(this.gameObject);
                }
            }).AddTo(this);
        }
    }
}
