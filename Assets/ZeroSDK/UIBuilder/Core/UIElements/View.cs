using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.Animator;


namespace ZeroSDK.UIBuilder.Core.UIElements
{
    [RequireComponent(typeof(CanvasGroup))]
    public class View : MonoBehaviour
    {
        public CanvasGroup CG;
        public RectTransform Rect;

        [SerializeField]
        public BaseAnimator InAnimation;

        [SerializeField]
        public BaseAnimator OutAnimation;

        [SerializeField]
        public BaseAnimator AttentionAnimator;

        [HideInInspector] public Action OnShowStartEvent = delegate { };
        [HideInInspector] public Action OnShowEndEvent = delegate { };
        [HideInInspector] public Action OnHideStartEvent = delegate { };
        [HideInInspector] public Action OnHideEndEvent = delegate { };
        [HideInInspector] public Queue<Action> ShowStartEventsQueue = new Queue<Action>();
        [HideInInspector] public Queue<Action> ShowEndEventsQueue = new Queue<Action>();
        [HideInInspector] public Queue<Action> HideStartEventsQueue = new Queue<Action>();
        [HideInInspector] public Queue<Action> HideEndEventsQueue = new Queue<Action>();

        [NonSerialized] [HideInInspector] public Vector3 InitLocalPosition;
        [NonSerialized] [HideInInspector] public Quaternion InitLocalRotation;
        [NonSerialized] [HideInInspector] public Vector3 InitLocalScale;


        protected Tween animationTween;
        protected Tween attentionTween;

        protected int attentionCount = 0;


        private void Awake()
        {
            // gameObject.EnsureComponent(ref CG);
        }

        public bool IsVisible
        {
            get => gameObject.activeSelf;
            set
            {
                if (value)
                    Show();
                else
                    Hide();
            }
        }

        public bool Interactable
        {
            get => CG.interactable;
            set
            {
                if (value)
                    EnableInteraction();
                else
                    DisableInteraction();
            }
        }


        public void Init()
        {
            OnShowStartEvent += OnShowStart;
            OnShowEndEvent += OnShowEnd;
            OnHideStartEvent += OnHideStart;
            OnHideEndEvent += OnHideEnd;

            OnHideEndEvent += Disable;
            OnShowStartEvent += Enable;

            OnShowStartEvent += () => InvokeQueueActions(ShowStartEventsQueue);
            OnShowEndEvent += () => InvokeQueueActions(ShowEndEventsQueue);
            OnHideStartEvent += () => InvokeQueueActions(HideStartEventsQueue);
            OnHideEndEvent += () => InvokeQueueActions(HideEndEventsQueue);

            InitLocalPosition = transform.localPosition;
            InitLocalRotation = transform.localRotation;
            InitLocalScale = transform.localScale;

            OnInit();

            if (!gameObject.activeSelf)
            {
                HideImmediately(false, false);
            }
        }


        public Tween Show(bool startCallback = true, bool endCallback = true)
        {
            animationTween?.Kill();
            animationTween = InAnimation.Animate(this)
                .OnStart(() =>
                {
                    if (startCallback)
                        OnShowStartEvent?.Invoke();
                })
                .OnComplete(() =>
                {
                    if (endCallback)
                        OnShowEndEvent?.Invoke();
                });
            return animationTween;
        }


        public void ShowImmediately(bool immediately = false, bool startCallback = true, bool endCallback = true)
        {
            animationTween?.Kill();
            if (startCallback)
                OnShowStartEvent?.Invoke();
            InAnimation.AnimateImmediately(this);
            if (endCallback)
                OnShowEndEvent?.Invoke();
        }

        public Tween Hide(bool startCallback = true, bool endCallback = true)
        {
            animationTween?.Kill();
            attentionTween?.Kill();
            animationTween = OutAnimation.Animate(this)
                .OnStart(() =>
                {
                    if (startCallback)
                        OnHideStartEvent?.Invoke();
                })
                .OnComplete(() =>
                {
                    if (endCallback)
                        OnHideEndEvent?.Invoke();
                });
            return animationTween;
        }


        public void HideImmediately(bool startCallback = true, bool endCallback = true)
        {
            animationTween?.Kill();
            if (startCallback)
                OnHideStartEvent?.Invoke();
            OutAnimation.AnimateImmediately(this);
            if (endCallback)
                OnHideEndEvent?.Invoke();
        }


        public void EnableAttention(int count)
        {
            attentionCount = count;
#pragma warning disable 4014
            AttentionLoop();
#pragma warning restore 4014
        }


        public void DisableAttention()
        {
            attentionCount = 0;
        }


        private async UniTask AttentionLoop()
        {
            while (attentionCount != 0)
            {
                attentionCount--;
                attentionTween?.Kill(true);
                attentionTween = AttentionAnimator.Animate(this);
                await attentionTween.AsyncWaitForCompletion();
            }
        }


        public void Enable()
        {
            gameObject.SetActive(true);
        }


        public void Disable()
        {
            gameObject.SetActive(false);
        }


        public void EnableInteraction()
        {
            CG.blocksRaycasts = true;
            CG.interactable = true;
        }


        public void DisableInteraction()
        {
            CG.blocksRaycasts = false;
            CG.interactable = false;
        }


        protected virtual void OnInit()
        {
        }


        protected virtual void OnShowStart()
        {
        }


        protected virtual void OnShowEnd()
        {
        }


        protected virtual void OnHideStart()
        {
        }


        protected virtual void OnHideEnd()
        {
        }


        private void InvokeQueueActions(Queue<Action> queue)
        {
            while (queue.Count > 0)
            {
                queue.Dequeue().Invoke();
            }
        }


#if UNITY_EDITOR
        protected virtual void Reset()
        {
            CG = GetComponent<CanvasGroup>();
            Rect = GetComponent<RectTransform>();
            if (UIManager.I.Config != null)
            {
                LoadDefaultConfig();
            }
        }


        protected virtual void LoadDefaultConfig()
        {
            InAnimation = UIManager.I.Config.Animation.DefaultInAnimator;
            OutAnimation = UIManager.I.Config.Animation.DefaultOutAnimator;
        }
#endif
    }
}