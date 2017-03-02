using UnityEngine;
using UniDialog.Domain;
using Fumobox.Presenter;
using Fumobox.Util;

namespace UniDialog.Presentation
{

    public abstract class DialogPresenter : PresenterBehaviour<IDialog>
    {
        protected DialogFramePresenter _framePresenter;

        protected DialogContentPresenter _contentPresenter;

        [SerializeField]
        protected RectTransform _dialogContainer = null;

        public virtual void Initialize(IDialog argument)
        {
            _framePresenter = UnityTools.Instantiate<DialogFramePresenter>(argument.Frame.PresenterPath, _dialogContainer.transform);
            _contentPresenter = UnityTools.Instantiate<DialogContentPresenter>(argument.Content.PresenterPath, _framePresenter.ContentContainer.transform);

            _framePresenter.Initialize(argument.Frame);
            _contentPresenter.Initialize(argument.Content);
        }

    }

}
