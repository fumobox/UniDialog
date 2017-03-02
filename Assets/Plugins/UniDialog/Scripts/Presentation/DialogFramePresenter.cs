using System.Collections;
using UniRx;
using UnityEngine;
using UniDialog.Domain;
using Fumobox.Presenter;

namespace UniDialog.Presentation
{

    public abstract class DialogFramePresenter : PresenterBehaviour<IDialogFrame>
    {
        [SerializeField]
        protected RectTransform _contentContainer = null;

        public RectTransform ContentContainer
        {
            get
            {
                return _contentContainer;
            }
        }

    }

}
