using UnityEngine;
using ZeroSDK.Utility.Singleton;

namespace _project.Scripts
{
    public sealed class GameSound : SingleScript<GameSound>
    {
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioSource coin;
        [SerializeField] private AudioSource press;

        public override void Awake()
        {
            base.Awake();
            if (PlayerPrefs.HasKey("Music")) SetMusicVolume(PlayerPrefs.GetFloat("Music"));
            if (PlayerPrefs.HasKey("Effects")) SetEffectsVolume(PlayerPrefs.GetFloat("Effects"));
        }

        public void SetMusicVolume(float v)
        {
            music.volume = v;
        }

        public void SetEffectsVolume(float v)
        {
            coin.volume = v;
            press.volume = v;
        }

        public override void OnDestroy()
        {
            PlayerPrefs.SetFloat("Music", music.volume);
            PlayerPrefs.SetFloat("Effects", coin.volume);

            PlayerPrefs.Save();
        }

        public void PlayPressSound()
        {
            press.Play();
        }

        public void PlayCoinSound()
        {
            coin.Play();
        }
    }
}