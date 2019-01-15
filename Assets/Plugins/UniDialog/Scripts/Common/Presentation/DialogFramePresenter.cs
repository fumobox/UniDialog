using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Presentation
{
    public abstract class DialogFramePresenter : MonoBehaviour
    {
        [SerializeField]
        protected RectTransform _contentContainer;

        public RectTransform ContentContainer
        {
            get
            {
                return _contentContainer;
            }
        }

        public virtual void Initialize(IDialogFrame argument)
        {
        }
    }
}
