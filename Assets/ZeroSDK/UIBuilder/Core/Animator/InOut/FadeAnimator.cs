﻿using DG.Tweening;
 using UnityEngine;
 using ZeroSDK.UIBuilder.Core.UIElements;


 namespace ZeroSDK.UIBuilder.Core.Animator.InOut
{
    [CreateAssetMenu(fileName = "FadeAnimator", menuName = "UIBuilder/InOut/FadeAnimator", order = 0)]
    public class FadeAnimator : BaseAnimator
    {
        [SerializeField] private float delay = 0f;
        [SerializeField] private float speed = 4f;
        [SerializeField] private float opacity = 1f;
        [SerializeField] private bool blocksRaycasts = true;
        [SerializeField] private Ease ease = Ease.OutQuad;

        public override Tween Animate(View view)
        {
            var tween = view.CG.DOFade(opacity, speed)
                .SetDelay(delay)
                .SetSpeedBased(true)
                .SetEase(ease)
                .SetUpdate(true);
            view.CG.blocksRaycasts = blocksRaycasts;
            return tween;
        }


        public override void AnimateImmediately(View view)
        {
            view.CG.alpha = opacity;
            view.CG.blocksRaycasts = blocksRaycasts;
        }
    }
}