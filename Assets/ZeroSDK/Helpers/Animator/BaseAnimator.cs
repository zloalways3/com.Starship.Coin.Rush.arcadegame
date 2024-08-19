using System;
using DG.Tweening;
using UnityEngine;


namespace ZeroSDK.Helpers.Animator
{
    [Serializable]
    public abstract class BaseAnimator<T> : ScriptableObject
    {
        public abstract Tween Animate(T obj);
        public abstract void AnimateImmediately(T obj);
    }
}