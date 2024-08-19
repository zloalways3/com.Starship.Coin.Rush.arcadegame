using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core.Animator.ToInitValues
{
    [CreateAssetMenu(fileName = "ToInitScale", menuName = "UIBuilder/ToInit/Scale", order = 0)]
    public class ToInitScale : BaseAnimator
    {
        [SerializeField] private float speed = 4f;
        [SerializeField] private Ease ease = Ease.OutQuad;


        public override Tween Animate(View view)
        {
            var tween = view.transform.DOScale(view.InitLocalScale, speed)
                .SetSpeedBased(true)
                .SetEase(ease)
                .SetUpdate(true);
            return tween;
        }


        public override void AnimateImmediately(View view)
        {
            view.transform.localScale = view.InitLocalScale;
        }
    }
}