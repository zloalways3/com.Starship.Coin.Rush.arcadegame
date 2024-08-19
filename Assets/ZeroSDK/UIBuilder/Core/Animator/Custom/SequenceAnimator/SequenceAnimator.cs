using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core.Animator.Custom.SequenceAnimator
{
    [CreateAssetMenu(fileName = "SequenceAnimator", menuName = "UIBuilder/SequenceAnimator", order = -1)]
    public class SequenceAnimator : BaseAnimator
    {
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private bool useStartPosition;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private List<SequenceAnimatorRow> animators;
        
        public override Tween Animate(View view)
        {
            if (useStartPosition)
            {
                view.transform.localPosition = startPosition;
            }

            var sequence = DOTween.Sequence();
            var iCount = animators.Count;
            for (var i = 0; i < iCount; i++)
            {
                switch (animators[i].order)
                {
                    case AnimationOrderType.Prepend:
                        sequence.Prepend(animators[i].Animator.Animate(view));
                        break;
                    case AnimationOrderType.Append:
                        sequence.Append(animators[i].Animator.Animate(view));
                        break;
                    case AnimationOrderType.Insert:
                        sequence.Insert(0,animators[i].Animator.Animate(view));
                        break;
                }

            }

            sequence
                .SetSpeedBased(true)
                .SetUpdate(true)
                .SetEase(ease);
            return sequence;
        }
        
        public override void AnimateImmediately(View view)
        {
            var iCount = animators.Count;
            for (var i = 0; i < iCount; i++)
            {
                animators[i].Animator.AnimateImmediately(view);
            }
        }
    }
}