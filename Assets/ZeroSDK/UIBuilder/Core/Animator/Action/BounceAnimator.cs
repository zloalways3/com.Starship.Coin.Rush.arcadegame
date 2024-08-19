using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core.Animator.Action
{
    [CreateAssetMenu(fileName = "BounceAnimator", menuName = "UIBuilder/Action/BounceAnimator", order = 0)]
    public class BounceAnimator : BaseAnimator
    {
        [SerializeField] private Vector3 punch;
        [SerializeField] private float delay;
        [SerializeField] private float duration;
        [SerializeField] private int vibrato = 10;
        [SerializeField] private float elasticity = 1f;
        [SerializeField] private Ease ease = Ease.OutQuad;


        public override Tween Animate(View view)
        {
            return view.transform.DOPunchScale(punch, duration, vibrato, elasticity)
                .SetDelay(delay)
                .SetEase(ease)
                .SetUpdate(true);
        }


        public override void AnimateImmediately(View view)
        {
            view.transform.localScale = view.InitLocalScale;
        }
    }
}