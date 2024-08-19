using System;
using _project.Scripts;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using ZeroSDK.UIBuilder.Core.Animator;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.AddOns
{
    public class ClickableView : View, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField]
        private bool HasSound = true;
        
        [SerializeField]
        protected BaseAnimator pointerDownAnimator;

        [SerializeField]
        protected BaseAnimator pointerUpAnimator;

        protected Tween pointerTween;
        protected bool IsInteractable { get; set; } = true;
        
        [SerializeField] private View viewContainer;

        public event Action OnDownEvent = delegate { };
        public event Action OnUpEvent = delegate { };
        public event Action OnClickEvent = delegate { };
        public event Action OnClickFailEvent = delegate { };


        public bool IsDown { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (HasSound)
            {
                GameSound.I.PlayPressSound();
            }
            
            IsDown = true;
            OnDownEvent?.Invoke();
            pointerTween?.Kill(true);
            pointerTween = pointerDownAnimator.Animate(viewContainer);
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            IsDown = false;
            OnUpEvent?.Invoke();
            pointerTween?.Kill(true);
            pointerTween = pointerUpAnimator.Animate(viewContainer);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsInteractable)
            {
                OnClickEvent?.Invoke();
            }
            else
            {
                OnClickFailEvent?.Invoke();
            }
        }


        public void RemoveAllOnDownEvents()
        {
            OnDownEvent = delegate { };
        }


        public void RemoveAllOnUpEvents()
        {
            OnUpEvent = delegate { };
        }


        public void RemoveAllOnClickEvents()
        {
            OnClickEvent = delegate { };
        }


        public void RemoveAllOnClickFailEvents()
        {
            OnClickFailEvent = delegate { };
        }
    }
}