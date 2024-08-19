using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace ZeroSDK.UIBuilder.Core.Animator.Action
{
    namespace MeowLab.UIBuilder.Core.Animator.Action
    {
        [CreateAssetMenu(fileName = "FadeAnimator", menuName = "UIBuilder/Action/FadeAnimator", order = 1)]
        public class FadeBounceAnimator : BaseAnimator
        {
            [SerializeField] private float targetFade;
            [SerializeField] private float initialFade;
            [SerializeField] private float fadeDelay;
            [SerializeField] private float waitTime;
            [SerializeField] private float duration;
            [SerializeField] private Ease ease = Ease.OutQuad;

            public override Tween Animate(View view)
            {
                Tween animationTween = DOTween.Sequence()
                    .Append(view.CG.DOFade(targetFade, duration)
                        .SetDelay(fadeDelay)
                        .SetEase(ease)
                        .SetUpdate(true))
                    .AppendInterval(waitTime)
                    .Append(view.CG.DOFade(initialFade, duration)
                        .SetDelay(fadeDelay)
                        .SetEase(ease)
                        .SetUpdate(true));
                return animationTween;
            }

            public override void AnimateImmediately(View view)
            {
                view.CG.alpha = initialFade;
            }
        }
    }
}