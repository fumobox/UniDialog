using UniDialog.Domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TweenRx;

namespace UniDialog.Presentation
{
    public class MenuDialogPresenter : DialogPresenter
    {
        [SerializeField]
        CanvasGroupFadeAnimator _canvasGroupFadeAnimator;

        [SerializeField]
        Button _outSideButton;

        public override void Initialize(IDialog argument, DialogTemplate template)
        {
            base.Initialize(argument, template);

            var fp = (MenuDialogFramePresenter)_framePresenter;

            var cd = (MenuDialog)argument;

            _outSideButton.OnClickAsObservable().Subscribe(_ =>
                {
                    if(argument.CloseOnTouchOutside)
                    {
                        argument.Close();
                    }
                }).AddTo(this);

            argument.ObserveEveryValueChanged(x => x.State).Subscribe(state =>
                {
                    switch(state)
                    {
                        case DialogState.Closed:
                            break;
                        case DialogState.Opening:
                            _canvasGroupFadeAnimator.FadeInAsObservable().Subscribe(_ => { }, () => argument.State = DialogState.Opened).AddTo(this);
                            break;
                        case DialogState.Opened:
                            break;
                        case DialogState.Closing:
                            _canvasGroupFadeAnimator.FadeOutAsObservable().Subscribe(_ => { }, () => argument.State = DialogState.Closed).AddTo(this);
                            break;
                    }
            }).AddTo(this);
        }
    }
}
