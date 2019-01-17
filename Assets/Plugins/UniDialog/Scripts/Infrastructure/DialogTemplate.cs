using UniDialog.Presentation;
using UnityEngine;

namespace UniDialog.Infrastructure
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
