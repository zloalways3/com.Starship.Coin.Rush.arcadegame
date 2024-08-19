using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class ChooseLevelScreen : ScreenView
    {
        [SerializeField] private ButtonView exitButton;
        [SerializeField] private List<ButtonView> levelButtons;

        public event Action OnExitButton
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }

        public event Action<int> OnTryChooseLevel;

        protected override void OnInit()
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                var id = i;
                levelButtons[i].OnClickEvent += () => OnTryChooseLevel?.Invoke(id);
            }
        }

        public void SetLevelsCount(int levelsCount)
        {
            for (int i = 0; i < Mathf.Min(levelsCount, levelButtons.Count); i++)
            {
                var fadeValue = i <= levelsCount - 1 ? 1 : 0.16f;
                levelButtons[i].CG.alpha = fadeValue;
            }
        }
    }
}