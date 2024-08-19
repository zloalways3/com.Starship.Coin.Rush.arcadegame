using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core.Animator.Custom.SequenceAnimator
{
    [CreateAssetMenu(fileName = "SequenceAnimatorDelay", menuName = "UIBuilder/SequenceAnimatorDelay", order = -1)]
    public class SequenceAnimatorDelay : BaseAnimator
    {
        [SerializeField] private float delay;


        public override Tween Animate(View view)
        {
            var a = 1;
            return DOTween.To(() => 1, (v) => a = v, 1, 0).SetDelay(delay);
        }


        public override void AnimateImmediately(View view)
        {
        }
    }
}