using UnityEngine;
using UnityEngine.UI;
using UniDialog.Domain;
using UniDialog.Presentation;
using UniDialog.Preset.Confirm.Domain;

namespace UniDialog.Preset.Confirm.Presentation
{

    public class ConfirmDialogContentPresenter : DialogContentPresenter
    {

        [SerializeField]
        Text _text = null;

        public override void Initialize(IDialogContent argument)
        {
            var model = (ConfirmDialogContentModel)argument;
            _text.text = model.Text;
        }
    }

}
