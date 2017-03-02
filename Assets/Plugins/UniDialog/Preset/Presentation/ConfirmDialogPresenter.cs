using UniDialog.Domain;
using UniDialog.Presentation;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Fumobox.Util;
using UniDialog.Preset.Confirm.Domain;

namespace UniDialog.Preset.Confirm.Presentation
{
    public class ConfirmDialogPresenter : DialogPresenter
    {
        [SerializeField]
        CanvasGroupFadeAnimator _canvasGroupFadeAnimator = null;

        [SerializeField]
        Button _outSideButton = null;

        public override void Initialize(IDialog argument)
        {
			Debug.Log("ConfirmDialogPresenter: Initialize");
            base.Initialize(argument);

            var fp = (ConfirmDialogFramePresenter)_framePresenter;

            var cd = (ConfirmDialog)argument;

            for (int i = 0; i < fp.Buttons.Count; i++)
            {
                if (i < cd.Buttons.Count)
                {
                    fp.Buttons[i].gameObject.SetActive(true);
                    var b = fp.Buttons[i];
                    b.Text = cd.Buttons[i].Name;
                    b.Model = cd.Buttons[i];
                    b.Button.OnClickAsObservable().Subscribe(_ =>
                        {
                            //Debug.LogWarning("Click");
                            b.Model.ClickStream.OnNext(argument);
                        }).AddTo(this);
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
                            _canvasGroupFadeAnimator.FadeIn(() => 
                                {
                                    argument.State = DialogState.Opened;
                                });
                            break;
                        case DialogState.Opened:
                            break;
                        case DialogState.Closing:
                            _canvasGroupFadeAnimator.FadeOut(() =>
                                {
                                    Debug.Log("Fadeout Complete");
                                    argument.State = DialogState.Closed;
                                });
                            break;
                    }
            }).AddTo(this);
        }
    }
}
