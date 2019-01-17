using UnityEngine;
using UniDialog.Domain;
using UniDialog.Infrastructure;

namespace UniDialog.Presentation
{

    public abstract class DialogPresenter : MonoBehaviour
    {
        protected DialogFramePresenter _framePresenter;

        protected DialogContentPresenter _contentPresenter;

        [SerializeField]
        protected RectTransform _dialogContainer;

        public virtual void Initialize(IDialog argument, DialogTemplate template)
        {
            _framePresenter = Instantiate(template.frame, _dialogContainer.transform, false);
            _contentPresenter = Instantiate(template.content, _framePresenter.ContentContainer, false);

            _framePresenter.Initialize(argument.Frame);
            _contentPresenter.Initialize(argument.Content);
        }
    }
}