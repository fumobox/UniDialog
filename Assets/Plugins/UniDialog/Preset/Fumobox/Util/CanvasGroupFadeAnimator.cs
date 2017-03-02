using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TweenRx;
using UniRx;

namespace Fumobox.Util
{
    public class CanvasGroupFadeAnimator : MonoBehaviour
    {
        CanvasGroup _canvasGroup = null;

        Action _onComplete;

        [SerializeField]
        float _fadeInFromAlpha = 0;

        [SerializeField]
        float _fadeInToAlpha = 1;

        [SerializeField]
        float _fadeInTime = 1;

        [SerializeField]
        Tween.EaseType _fadeInEaseType = Tween.EaseType.EaseInCubic;

        [SerializeField]
        float _fadeOutFromAlpha = 1;

        [SerializeField]
        float _fadeOutToAlpha = 0;

        [SerializeField]
        float _fadeOutTime = 1;

        [SerializeField]
        Tween.EaseType _fadeOutEaseType = Tween.EaseType.EaseOutCubic;

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeIn(Action onComplete)
        {
            Tween.Play(
                _fadeInFromAlpha,
                _fadeInToAlpha,
                _fadeInTime,
                _fadeInEaseType
            ).Subscribe(a =>
                {
                    _canvasGroup.alpha = a;
                },
                () =>
                {
                    if (onComplete != null)
                        onComplete();
                }
            );
        }

        public void FadeOut(Action onComplete)
        {
            Tween.Play(
                _fadeOutFromAlpha,
                _fadeOutToAlpha,
                _fadeOutTime,
                _fadeOutEaseType
            ).Subscribe(a =>
                {
                    _canvasGroup.alpha = a;
                },
                () =>
                {
                    if(onComplete != null)
                        onComplete();
                }
            );
        }

    }

}
