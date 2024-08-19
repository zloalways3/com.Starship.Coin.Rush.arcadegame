using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core.Animator.InOut
{
    [CreateAssetMenu(fileName = "BlendableScreenTranslateAnimator", menuName = "UIBuilder/InOut/Blendable/ScreenTranslateAnimator", order = 1)]
    public class BlendableScreenTranslateAnimator : BaseAnimator
    {
        [SerializeField] private float duration = 4f;
        [SerializeField] private Vector2 offsetSizePercetage;
        [SerializeField] private bool blocksRaycasts = true;
        [SerializeField] private bool isShowAnimator;
        [SerializeField] private Ease ease = Ease.OutQuad;


        public override Tween Animate(View view)
        {
            SetAlpha(view, true);

            //Vector2 localRectPos = Camera.main.WorldToScreenPoint(view.InitLocalPosition);
            var tween2 = view.Rect.DOAnchorPos(view.Rect.rect.size * offsetSizePercetage, duration)
                .SetEase(ease)
                .SetUpdate(true)
                .OnComplete(()=>SetAlpha(view, false))
                ;

            //var tween = view.transform.DOLocalMove(offset, speed)
            //    .SetSpeedBased(true)
            //    .SetEase(ease)
            //    .SetUpdate(true);
            view.CG.blocksRaycasts = blocksRaycasts;
            return tween2;
        }


        public override void AnimateImmediately(View view)
        {
            SetAlpha(view, true);
            SetAlpha(view, false);

            Vector2 ini = Camera.main.WorldToScreenPoint(view.InitLocalPosition);
            view.Rect.anchoredPosition = ini + new Vector2(Screen.width, Screen.height);

            //view.transform.localPosition = view.InitLocalPosition + offset;
            view.CG.blocksRaycasts = blocksRaycasts;
        }

        private void SetAlpha(View view, bool onTransitionStart)
        {
            if(onTransitionStart)
            {
                if(isShowAnimator)
                {
                    view.CG.alpha = 1;
                }
            }
            else
            {
                if (!isShowAnimator)
                {
                    view.CG.alpha = 0;
                }
            }
        }
    }
}