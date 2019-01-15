using UnityEngine;
using UnityEngine.UI;
using UniDialog.Domain;

namespace UniDialog.Presentation
{

    public class ConfirmDialogContentPresenter : DialogContentPresenter
    {

        [SerializeField]
        Text _text;

        public override void Initialize(IDialogContent argument)
        {
            var model = (ConfirmDialogContentModel)argument;
            _text.text = model.Text;
        }
    }

}
