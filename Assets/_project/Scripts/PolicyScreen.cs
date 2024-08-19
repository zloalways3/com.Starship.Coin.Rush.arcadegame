using System;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class PolicyScreen : ScreenView
    {
        [SerializeField] private ButtonView exitButton;
        
        public event Action OnExitButton
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }
    }
}