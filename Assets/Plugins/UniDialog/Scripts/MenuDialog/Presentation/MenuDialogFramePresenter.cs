using UniDialog.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace UniDialog.Presentation
{
    public class MenuDialogFramePresenter : DialogFramePresenter
    {
        [SerializeField]
        Text _titleText;

        public override void Initialize(IDialogFrame argument)
        {
            var model = (MenuDialogFrameModel)argument;
            _titleText.text = model.Title;
        }
    }
}