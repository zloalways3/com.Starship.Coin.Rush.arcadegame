using DG.Tweening;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core.Animator.InOut
{
    [System.Serializable]
    public class SwoopAnimator : BaseAnimator
    {
        public override Tween Animate(View view)
        {
            return null;
        }


        public override void AnimateImmediately(View view)
        {
        }


        // [SerializeField] private Vector2 inOffset;
        // [SerializeField] private Vector2 outOffset;
        // [SerializeField] private Vector3 inScale = Vector3.one;
        // [SerializeField] private Vector3 outScale = Vector3.zero;
        //
        // [Space] [SerializeField] private float inDuration;
        // [SerializeField] private float outDuration;
        //
        //
        // [Space] [SerializeField] private Ease inMoveEase;
        // [SerializeField] private float inMoveEaseAmplitude = 1.70158f;
        // [SerializeField] private float inMoveEasePeriod = 0f;
        // [SerializeField] private Ease outMoveEase;
        // [SerializeField] private float outMoveEaseAmplitude = 1.70158f;
        // [SerializeField] private float outMoveEasePeriod = 0f;
        //
        //
        // [Space] [SerializeField] private Ease inScaleEase;
        // [SerializeField] private float inScaleEaseAmplitude = 1.70158f;
        // [SerializeField] private float inScaleEasePeriod = 0f;
        // [SerializeField] private Ease outScaleEase;
        // [SerializeField] private float outScaleEaseAmplitude = 1.70158f;
        // [SerializeField] private float outScaleEasePeriod = 0f;
        //
        //
        // private Vector2 anchoredPosition;
        // // private Vector2 inAnchoredPosition;
        // // private Vector2 outAnchoredPosition;
        //
        // public override void Init(View view)
        // {
        //     base.Init(view);
        //
        //     anchoredPosition = view.Rect.anchoredPosition;
        //     // inAnchoredPosition = anchoredPosition - inOffset;
        //     // outAnchoredPosition = anchoredPosition + outOffset;
        // }
        //
        // public override void ShowAnimation()
        // {
        //     view.Rect.DOKill();
        //     view.Rect.anchoredPosition = anchoredPosition - inOffset;
        //     view.Rect.localScale = outScale;
        //     view.CG.alpha = 1f;
        //
        //     view.Rect.DOAnchorPos(anchoredPosition, inDuration)
        //         .OnStart(() => view.OnShowStartEvent())
        //         .OnComplete(() => view.OnShowEndEvent())
        //         .SetEase(inMoveEase, inMoveEaseAmplitude, inMoveEasePeriod)
        //         .SetUpdate(true);
        //
        //     view.Rect.DOScale(inScale, inDuration)
        //         .SetEase(inScaleEase, inScaleEaseAmplitude, inScaleEasePeriod)
        //         .SetUpdate(true);
        //
        //
        //     view.CG.blocksRaycasts = true;
        // }
        //
        //
        // public override void HideAnimation()
        // {
        //     view.Rect.DOKill();
        //
        //     view.Rect.DOAnchorPos(anchoredPosition + outOffset, outDuration)
        //         .OnStart(() => view.OnHideStartEvent())
        //         .OnComplete(() => view.OnHideEndEvent())
        //         .SetEase(outMoveEase, outMoveEaseAmplitude, outMoveEasePeriod)
        //         .SetUpdate(true);
        //
        //     view.Rect.DOScale(outScale, outDuration)
        //         .SetEase(outScaleEase, outScaleEaseAmplitude, outScaleEasePeriod)
        //         .SetUpdate(true);
        //
        //
        //     view.CG.blocksRaycasts = false;
        // }
        //
        // public override void ShowImmediately()
        // {
        //     view.Rect.DOKill();
        //     view.Rect.anchoredPosition = anchoredPosition;
        //     view.Rect.localScale = inScale;
        //     view.CG.blocksRaycasts = true;
        //     view.CG.alpha = 1f;
        // }
        //
        //
        // public override void HideImmediately()
        // {
        //     view.Rect.DOKill();
        //     view.Rect.anchoredPosition = anchoredPosition + outOffset;
        //     view.Rect.localScale = outScale;
        //     view.CG.blocksRaycasts = false;
        //     view.CG.alpha = 0f;
        // }
    }
}