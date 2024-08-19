using System;
using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace ZeroSDK.UIBuilder.AddOns
{
    [Serializable]
    public class DisplayableView
    {
        [SerializeField] private View targetView;
        [SerializeField] private Vector2 targetPosition;
        [SerializeField] private float showingDuration;
        [SerializeField] private float showingHeight;

        public View TargetView => targetView;
        
        private Sequence animSequence;

        public Sequence SetupFor(View targetView, float showingDuration, float showingHeight)
        {
            this.targetView = targetView;
            this.targetPosition = this.targetView.Rect.anchoredPosition;
            this.showingDuration = showingDuration;
            this.showingHeight = showingHeight;
            
            animSequence?.Kill();
            return animSequence = DOTween.Sequence()
                .AppendCallback(() =>
                {
                    targetView.DisableInteraction();
                    targetView.CG.alpha = 0;
                    targetView.Rect.anchoredPosition = targetPosition - new Vector2(0, showingHeight);
                })
                .Append(this.targetView.Rect
                    .DOAnchorPosY(targetPosition.y, showingDuration)
                    .SetEase(Ease.OutBack))
                .Join(targetView.CG
                    .DOFade(1, showingDuration)
                    .SetEase(Ease.InOutSine))
                .OnComplete(targetView.EnableInteraction)
                .OnKill(() =>
                {
                    targetView.EnableInteraction();
                    targetView.CG.alpha = 1;
                    targetView.Rect.anchoredPosition = targetPosition;
                })
                .Pause()
                .SetAutoKill(false);
        }
    }
}