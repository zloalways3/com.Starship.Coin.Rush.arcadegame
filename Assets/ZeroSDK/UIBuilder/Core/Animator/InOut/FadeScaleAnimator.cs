﻿using DG.Tweening;
 using ZeroSDK.UIBuilder.Core.UIElements;


 namespace ZeroSDK.UIBuilder.Core.Animator.InOut
{
    public class FadeScaleAnimator : BaseAnimator
    {
        public override Tween Animate(View view)
        {
            return null;
        }


        public override void AnimateImmediately(View view)
        {
        }
        
//        private Vector3 hiddenScale = new Vector3(1.5f, 1.5f, 1.5f);
//        private Vector3 shownScale = Vector3.one;
//
//        public FadeScaleAnimator(View view, AnimationData data) : base(view, data)
//        {
//
//        }
//
//        public override void ShowAnimation()
//        {
//            var duration = data.InDuration;
//            var ease = data.InEase;
//
//            view.CG.DOKill();
//            view.CG.DOFade(1f, data.InDuration)
//                .OnStart(() => OnShowAnimationStarted())
//                .OnComplete(() => OnShowAnimationFinished())
//                .SetEase(data.InEase);
//            view.CG.blocksRaycasts = true;
//
//            view.Rect.DOKill();
//            view.Rect.DOScale(shownScale, duration);
//        }
//
//        public override void HideAnimation()
//        {
//            var duration = data.OutDuration;
//            var ease = data.OutEase;
//
//            view.CG.DOKill();
//            view.CG.DOFade(0f, data.OutDuration)
//                .OnStart(() => OnHideAnimationStarted())
//                .OnComplete(() => OnHideAnimationFinished())
//                .SetEase(data.OutEase);
//            view.CG.blocksRaycasts = false;
//
//            view.Rect.DOKill();
//            view.Rect.DOScale(hiddenScale, duration);
//        }
    }
}