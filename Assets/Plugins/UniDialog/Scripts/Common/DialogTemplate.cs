using UniDialog.Presentation;
using UnityEngine;

namespace UniDialog
{

    [CreateAssetMenu]
    public class DialogTemplate : ScriptableObject
    {
        public string templateName;

        public DialogPresenter dialog;

        public DialogFramePresenter frame;

        public DialogContentPresenter content;
    }

}
