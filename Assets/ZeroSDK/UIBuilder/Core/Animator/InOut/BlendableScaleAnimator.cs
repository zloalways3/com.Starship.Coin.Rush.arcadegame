﻿using DG.Tweening;
 using UnityEngine;
 using ZeroSDK.UIBuilder.Core.UIElements;


 namespace ZeroSDK.UIBuilder.Core.Animator.InOut
{
    [CreateAssetMenu(fileName = "BlendableScaleAnimator", menuName = "UIBuilder/InOut/Blendable/ScaleAnimator", order = 0)]
    public class BlendableScaleAnimator : BaseAnimator
    {
        [SerializeField] private float delay = 0f;
        [SerializeField] private float speed = 4f;
        [SerializeField] private Vector3 scale;
        [SerializeField] private bool blocksRaycasts = true;
        [SerializeField] private Ease ease = Ease.OutQuad;


        public override Tween Animate(View view)
        {
            var tween = view.transform.DOBlendableScaleBy(scale, speed)
                .SetDelay(delay)
                .SetSpeedBased(true)
                .SetEase(ease)
                .SetUpdate(true);
            view.CG.blocksRaycasts = blocksRaycasts;
            return tween;
        }


        public override void AnimateImmediately(View view)
        {
            view.transform.localScale = view.InitLocalScale + scale;
            view.CG.blocksRaycasts = blocksRaycasts;
        }


        // [SerializeField] private float duration = 0.1f;
        //
        // [SerializeField] private Vector3 minScale;
        // [SerializeField] private Vector3 maxScale;
        // [SerializeField] private Ease fadeEaseIn = Ease.OutQuad;
        // [SerializeField] private Ease fadeEaseOut = Ease.InQuad;
        //
        // public override void ShowAnimation()
        // {
        //     view.transform.DOKill();
        //     view.transform.DOScale(maxScale, duration)
        //         .OnStart(() => view.OnShowStartEvent())
        //         .OnComplete(() => view.OnShowEndEvent())
        //         .SetEase(fadeEaseIn)
        //         .SetUpdate(true);
        //     view.CG.blocksRaycasts = true;
        // }
        //
        // public override void HideAnimation()
        // {
        //     view.transform.DOKill();
        //     view.transform.DOScale(minScale, duration)
        //         .OnStart(() => view.OnHideStartEvent())
        //         .OnComplete(() => view.OnHideEndEvent())
        //         .SetEase(fadeEaseOut)
        //         .SetUpdate(true);
        //     view.CG.blocksRaycasts = false;
        // }
        //
        // public override void ShowImmediately()
        // {
        //     view.transform.DOKill();
        //     view.transform.localScale = maxScale;
        //     view.CG.blocksRaycasts = true;
        // }
        //
        // public override void HideImmediately()
        // {
        //     view.transform.DOKill();
        //     view.transform.localScale = minScale;
        //     view.CG.blocksRaycasts = false;
        // }
    }
}