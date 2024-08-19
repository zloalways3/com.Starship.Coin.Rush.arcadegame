using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using ZeroSDK.GameCore.Manager;
using ZeroSDK.UIBuilder.Config;
using ZeroSDK.UIBuilder.Core.UIElements;


namespace ZeroSDK.UIBuilder.Core
{
    public class UIManager : SingleManager<UIManager>
    {
        [SerializeField] private Camera uiCamera;
        [SerializeField] private UIEffects uiEffects;
        [SerializeField] private UIConfig config;
        [SerializeField] private ScreenView[] screens;

        public Camera UICamera => uiCamera;
        public UIEffects Effects => uiEffects;
        public UIConfig Config => config;

        public override void Init()
        {
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var window = screens[i];
                window.Init();

                window.HideImmediately();

                if (window.ShowOnInit)
                {
                    window.ShowImmediately();
                }
            }
        }

        public ScreenView Show(Type type, bool isSolo = true, bool startCallback = true, bool endCallback = true)
        {
            var w = default(ScreenView);
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;

                if (w == null && screen.GetType() == type)
                {
                    w = screen;
                    screen.Show(startCallback, endCallback);
                }
                else
                {
                    if (isSolo)
                    {
                        screen.Hide(startCallback, endCallback);
                    }
                }
            }

            return w;
        }

        
        public T Show<T>(bool isSolo = true, bool startCallback = true, bool endCallback = true) where T : ScreenView
        {
            // Debug.Log(typeof(T));
            var w = default(ScreenView);
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;

                if (w == null && screen is T)
                {
                    w = screen;
                    screen.Show(startCallback, endCallback);
                }
                else
                {
                    if (isSolo)
                    {
                        screen.Hide(startCallback, endCallback);
                    }
                }
            }

            return w as T;
        }

        public async UniTask<T> ShowAsync<T>(bool isSolo = true, bool startCallback = true, bool endCallback = true)
            where T : ScreenView
        {
            // Debug.Log(typeof(T));
            var w = default(ScreenView);
            var list = new List<UniTask>();
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;

                if (w == null && screen is T)
                {
                    w = screen;
                    var tween = screen.Show(startCallback, endCallback);
                    list.Add(tween.AsyncWaitForCompletion().AsUniTask());
                }
                else
                {
                    if (isSolo)
                    {
                        var tween = screen.Hide(startCallback, endCallback);
                        list.Add(tween.AsyncWaitForCompletion().AsUniTask());
                    }
                }
            }

            await UniTask.WhenAll(list);

            return w as T;
        }


        public T ShowImmediately<T>(bool isSolo = true, bool startCallback = true, bool endCallback = true)
            where T : ScreenView
        {
            // Debug.Log(typeof(T));
            var w = default(ScreenView);
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;

                if (w == null && screen is T)
                {
                    w = screen;
                    screen.ShowImmediately(startCallback, endCallback);
                }
                else
                {
                    if (isSolo)
                    {
                        screen.HideImmediately(startCallback, endCallback);
                    }
                }
            }

            return w as T;
        }


        public T Hide<T>(bool startCallback = true, bool endCallback = true) where T : ScreenView
        {
            var w = default(ScreenView);
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;
                if (w == null && screen is T)
                {
                    w = screen;
                    screen.Hide(startCallback, endCallback);
                }
            }

            return w as T;
        }


        public T HideImmediately<T>(bool startCallback = true, bool endCallback = true) where T : ScreenView
        {
            var w = default(ScreenView);
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var screen = screens[i];
                if (screen.Ignore) continue;
                if (w == null && screen is T)
                {
                    w = screen;
                    screen.HideImmediately(startCallback, endCallback);
                }
            }

            return w as T;
        }


        public T GetWindow<T>()
        {
            var length = screens.Length;
            for (var i = 0; i < length; i++)
            {
                var window = screens[i];
                if (window is T w)
                {
                    return w;
                }
            }

            return default;
        }
    }
}