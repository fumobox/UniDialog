using TweenRx;
using UniDialog.Domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniDialog.Presentation
{
    public class ConfirmDialogPresenter : DialogPresenter
    {
        [SerializeField]
        CanvasGroupFadeAnimator _canvasGroupFadeAnimator;

        [SerializeField]
        Button _outSideButton;

        public override void Initialize(IDialog argument, DialogTemplate template)
        {
            base.Initialize(argument, template);

            var fp = (ConfirmDialogFramePresenter)_framePresenter;

            var cd = (ConfirmDialog)argument;

            for (int i = 0; i < fp.Buttons.Count; i++)
            {
                if (i < cd.Buttons.Count)
                {
                    fp.Buttons[i].gameObject.SetActive(true);
                    var b = fp.Buttons[i];
                    cd.Buttons[i].Owner = argument;
                    b.Initialize(cd.Buttons[i]);
                }
                else
                {
                    fp.Buttons[i].gameObject.SetActive(false);
                }
            }

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
