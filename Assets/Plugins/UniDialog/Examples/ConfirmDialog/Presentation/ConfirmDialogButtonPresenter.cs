using UniRx;
using UnityEngine;
using UniDialog.Domain;
using UnityEngine.UI;

namespace UniDialog.Presentation
{

    public class ConfirmDialogButtonPresenter: DialogButtonPresenter
    {
        [SerializeField]
        Button _button;

        [SerializeField]
        Text _text;

        IDialogButton _model;

        public int id;

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

        public override void Initialize(IDialogButton argument)
        {
            _model = argument;

            if (_model == null)
               	return;

            _text.text = _model.Name;

            _button.OnClickAsObservable().Subscribe(_ =>
            {
                _model.Owner.Click(_model);
        	}).AddTo(this);
        }

    }

}
