using System;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class PolicyPopupScreen : ScreenView
    {
        [SerializeField] private ButtonView okButton;
        [SerializeField] private ButtonView policyButton;
        
        public event Action OnOkButton
        {
            add => okButton.OnClickEvent += value;
            remove => okButton.OnClickEvent += value;
        }
        
        public event Action OnPolicyButton
        {
            add => policyButton.OnClickEvent += value;
            remove => policyButton.OnClickEvent += value;
        }
    }
}