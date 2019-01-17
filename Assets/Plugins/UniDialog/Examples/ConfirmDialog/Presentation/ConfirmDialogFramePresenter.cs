using System.Collections.Generic;
using UniDialog.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace UniDialog.Presentation
{

    public class ConfirmDialogFramePresenter : DialogFramePresenter
    {
        [SerializeField]
        List<ConfirmDialogButtonPresenter> _buttons;

        [SerializeField]
        Text _titleText;

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
                    t.sizeDelta = new Vector2(1280, 280);
                    break;
                case ConfirmDialogSize.Small:
                    t.anchorMin = new Vector2(0.5f, 0.5f);
                    t.anchorMax = new Vector2(0.5f, 0.5f);
                    t.pivot = new Vector2(0.5f, 0.5f);
                    t.sizeDelta = new Vector2(1280, 400);
                    break;
                case ConfirmDialogSize.Medium:
                    break;
                case ConfirmDialogSize.Large:
                    break;
                default:
                    break;
            }
        }
    }

}
