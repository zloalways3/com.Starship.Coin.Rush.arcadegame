using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace ZeroSDK.UIBuilder.Core.Animator.InOut
{
    [CreateAssetMenu(fileName = "ScaleAnimator", menuName = "UIBuilder/InOut/ScaleAnimator", order = 0)]
    public class ScaleAnimator : BaseAnimator
    {
        [SerializeField] private float delay = 0f;
        [SerializeField] private float speed = 4f;
        [SerializeField] private Vector3 scale;
        [SerializeField] private bool blocksRaycasts = true;
        [SerializeField] private Ease ease = Ease.OutQuad;


        public override Tween Animate(View view)
        {
            var tween = view.transform.DOScale(scale, speed)
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
    }
}