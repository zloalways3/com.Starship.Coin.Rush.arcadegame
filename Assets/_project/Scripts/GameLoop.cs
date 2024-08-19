using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZeroSDK.UIBuilder.Core;
using ZeroSDK.UIBuilder.Core.UIElements;

namespace _project.Scripts
{
    [DefaultExecutionOrder(1)]
    public sealed class GameLoop : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private Levels levels;


        private ScreenView _lastScreen;
        private LevelData _lastLevel;
        private int _availableLevels = 1;

        private async void Awake()
        {
            if (PlayerPrefs.HasKey("Levels"))
            {
                _availableLevels = Mathf.Max(1, PlayerPrefs.GetInt("Levels"));
            }

            uiManager.Init();
            InitWindows();
            
            
            uiManager.ShowImmediately<LoadingScreen>();
            await UniTask.WaitForSeconds(2);
            TryShowPopupOrMenu();
        }

        private void InitWindows()
        {
            var popup = uiManager.GetWindow<PolicyPopupScreen>();
            popup.OnOkButton += () =>
            {
                PlayerPrefs.SetInt("PolicySkipped", 1);
                uiManager.Show<MenuScreen>();
            };
            popup.OnPolicyButton += () => uiManager.Show<PolicyScreen>();


            var menu = uiManager.GetWindow<MenuScreen>();
            menu.OnPolicyButton += () => uiManager.Show<PolicyScreen>();
            menu.OnPlayButton += () => uiManager.Show<ChooseLevelScreen>();
            menu.OnOptionsButton += () => ShowOptionsScreen(menu);
            menu.OnExitButton += Application.Quit;


            var policy = uiManager.GetWindow<PolicyScreen>();
            policy.OnExitButton += () =>
            {
                PlayerPrefs.SetInt("PolicySkipped", 1);
                uiManager.Show<MenuScreen>();
            };


            var options = uiManager.GetWindow<OptionsScreen>();
            options.OnExitButton += () => uiManager.Show(_lastScreen.GetType());


            var chooseLevel = uiManager.GetWindow<ChooseLevelScreen>();
            chooseLevel.SetLevelsCount(_availableLevels);
            chooseLevel.OnExitButton += () => uiManager.Show<MenuScreen>();
            chooseLevel.OnTryChooseLevel += level =>
            {
                if(level > _availableLevels-1)
                    return;
                
                var screen = uiManager.Show<GameScreen>();
                screen.StartGame(levels.GameLevels[level]);
            };


            var gameScreen = uiManager.GetWindow<GameScreen>();

            gameScreen.OnMenuButton += () => uiManager.Show<ChooseLevelScreen>();
            gameScreen.OnSettingsButton += () => ShowOptionsScreen(gameScreen);

            gameScreen.OnExitButton += () =>
            {
                uiManager.Show<ChooseLevelScreen>();
                gameScreen.StopGame();
            };
            
            gameScreen.OnLevelComplete += data =>
            {
                _lastLevel = data;
                _availableLevels = Mathf.Clamp(_availableLevels + 1, 0, levels.GameLevels.Count);
                
                PlayerPrefs.SetInt("Levels", _availableLevels);
                PlayerPrefs.Save();
                
                chooseLevel.SetLevelsCount(_availableLevels);
            };

            gameScreen.OnRetryButton += () =>
            {
                var level = levels.GameLevels.First(l => l == _lastLevel);
                gameScreen.StartGame(level);
            };

            gameScreen.OnNextButton += () =>
            {
                for (int i = 0; i < levels.GameLevels.Count; i++)
                {
                    if (_lastLevel == levels.GameLevels[i])
                    {
                        var index = Mathf.Clamp(i + 1, 0, levels.GameLevels.Count);
                        gameScreen.StartGame(levels.GameLevels[index]);
                        return;
                    }
                }
            };
        }

        private void TryShowPopupOrMenu()
        {
            if (PlayerPrefs.HasKey("PolicySkipped") == false || PlayerPrefs.GetInt("PolicySkipped") == 0)
                uiManager.Show<PolicyPopupScreen>();
            else
                uiManager.Show<MenuScreen>();
        }

        private OptionsScreen ShowOptionsScreen(ScreenView lastScreen)
        {
            _lastScreen = lastScreen;
            return uiManager.Show<OptionsScreen>();
        }
    }
}