using System.Collections;
using System.Collections.Generic;
using UniDialog.Preset.Confirm.Domain;
using UniDialog.Domain;
using UniDialog.Presentation;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniDialog.Preset.Confirm.Presentation
{

    public class ConfirmDialogFramePresenter : DialogFramePresenter
    {
        [SerializeField]
        List<ConfirmDialogButtonPresenter> _buttons = null;

        [SerializeField]
        Text _titleText = null;

        public List<ConfirmDialogButtonPresenter> Buttons
        {
            get
            {
                return _buttons;
            }
        }

        public override void Initialize(IDialogFrame argument)
        {
            var model = (ConfirmDialogFrameModel)argument;

            _titleText.text = model.Title;

            RectTransform t = (RectTransform)(transform.parent);

            switch (model.Size)
            {
                case ConfirmDialogSize.Minimum:
                    t.anchorMin = new Vector2(0.5f, 0.5f);
                    t.anchorMax = new Vector2(0.5f, 0.5f);
                    t.pivot = new Vector2(0.5f, 0.5f);
                    t.sizeDelta = new Vector2(1280, 240);
                    break;
                default:
                    break;
            }
        }
    }

}
