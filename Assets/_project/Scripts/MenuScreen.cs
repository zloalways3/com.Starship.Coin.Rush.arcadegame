using System;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class MenuScreen : ScreenView
    {
        [SerializeField] private ButtonView policyButton;
        [SerializeField] private ButtonView playButton;
        [SerializeField] private ButtonView optionsButton;
        [SerializeField] private ButtonView exitButton;
        
        public event Action OnPlayButton
        {
            add => playButton.OnClickEvent += value;
            remove => playButton.OnClickEvent += value;
        }
        
        public event Action OnOptionsButton
        {
            add => optionsButton.OnClickEvent += value;
            remove => optionsButton.OnClickEvent += value;
        }
        
        public event Action OnExitButton
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }
        
        public event Action OnPolicyButton
        {
            add => policyButton.OnClickEvent += value;
            remove => policyButton.OnClickEvent += value;
        }
        
    }
}