using System.Collections;
using UniRx;
using UnityEngine;
using UniDialog.Domain;
using UnityEngine.UI;
using UnityEngine.Events;
using UniDialog.Presentation;

namespace UniDialog.Preset.Confirm.Presentation
{

    public class ConfirmDialogButtonPresenter: MonoBehaviour
    {
        [SerializeField]
        Button _button = null;

        [SerializeField]
        Text _text = null;

        IDialogButton _model;

        public int id;

        public Button Button
        {
            get
            {
                return _button;
            }
        }

        public IDialogButton Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;

                if (_model == null)
                    return;

                _text.text = _model.Name;
            }
        }

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

        void OnDestroy()
        {
            if(_model != null)
                _model.ClickStream.Dispose();
        }

    }

}
