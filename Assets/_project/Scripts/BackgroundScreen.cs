using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class BackgroundScreen : ScreenView
    {
        [SerializeField] private View blurView;

        public Tween EnableBlur() => blurView.Show();
        public Tween DisableBlur() => blurView.Hide();
    }
}