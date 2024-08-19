using System;
using ZeroSDK.UIBuilder.Core.Animator;


namespace ZeroSDK.UIBuilder.Config
{
    [Serializable]
    public class AnimationConfig
    {
        public BaseAnimator DefaultInAnimator;
        public BaseAnimator DefaultOutAnimator;
    }
}