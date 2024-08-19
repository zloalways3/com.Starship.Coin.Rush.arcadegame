﻿using System;
 using DG.Tweening;
 using UnityEngine;
 using ZeroSDK.UIBuilder.Core.UIElements;


 namespace ZeroSDK.UIBuilder.Core.Animator
{
    [Serializable]
    public abstract class BaseAnimator : ScriptableObject
    {
        public abstract Tween Animate(View views);
        public abstract void AnimateImmediately(View view);
    }
}