using System;
using UnityEngine;
using UnityEngine.UI;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    public sealed class OptionsScreen : ScreenView
    {
        [SerializeField] private ButtonView exitButton;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        public event Action OnExitButton
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }

        protected override void OnInit()
        {
            if (PlayerPrefs.HasKey("Music")) musicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Music"));
            if (PlayerPrefs.HasKey("Effects")) soundSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Effects"));

            musicSlider.onValueChanged.AddListener(v => GameSound.I.SetMusicVolume(v));
            soundSlider.onValueChanged.AddListener(v => GameSound.I.SetEffectsVolume(v));
        }
    }
}