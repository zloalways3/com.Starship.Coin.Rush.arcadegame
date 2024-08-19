using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using ZeroSDK.UIBuilder.AddOns.Button;
using ZeroSDK.UIBuilder.Core;
using ZeroSDK.UIBuilder.Core.UIElements;
using Random = UnityEngine.Random;

namespace _project.Scripts
{
    public sealed class GameScreen : ScreenView
    {
        [SerializeField] private ButtonView exitButton;
        [SerializeField] private ButtonView settingsButton;
        [SerializeField] private ButtonView leftButton;
        [SerializeField] private ButtonView rightButton;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private View gameView;
        [SerializeField] private View winView;
        [SerializeField] private TextMeshProUGUI winScoreText;
        [SerializeField] private ButtonView nextButton;
        [SerializeField] private ButtonView menuButton;
        [SerializeField] private ButtonView retryButton;
        [SerializeField] private List<RectTransform> coins = new List<RectTransform>();
        [SerializeField] private RectTransform ship;

        private CancellationTokenSource _tokenSource;

        public event Action OnExitButton
        {
            add => exitButton.OnClickEvent += value;
            remove => exitButton.OnClickEvent += value;
        }

        public event Action OnSettingsButton
        {
            add => settingsButton.OnClickEvent += value;
            remove => settingsButton.OnClickEvent += value;
        }

        public event Action OnNextButton
        {
            add => nextButton.OnClickEvent += value;
            remove => nextButton.OnClickEvent += value;
        }

        public event Action OnMenuButton
        {
            add => menuButton.OnClickEvent += value;
            remove => menuButton.OnClickEvent += value;
        }

        
        public event Action OnRetryButton
        {
            add => retryButton.OnClickEvent += value;
            remove => retryButton.OnClickEvent += value;
        }

        public event Action<LevelData> OnLevelComplete;

        [SerializeField] private bool DEBUG_FINISH;
        
        
        public async void StartGame(LevelData data)
        {
            gameView.ShowImmediately();
            winView.HideImmediately();
            
            _tokenSource?.Cancel();
            _tokenSource = new CancellationTokenSource();

            var time = data.time;
            var lastSpawnTime = data.coinsRate;
            var score = 0;

            timeText.text = $"Time: {(int) time}s";
            scoreText.text = "Score: 000p";

            while (time > 0 && DEBUG_FINISH == false)
            {
                await UniTask.Yield(_tokenSource.Token)
                    .SuppressCancellationThrow();

                time -= Time.deltaTime;
                lastSpawnTime -= Time.deltaTime;

                timeText.text = $"Time: {(int) time}s";

                if (_tokenSource.IsCancellationRequested)
                    return;

                UpdateShip(data);
                
                foreach (var coin in coins)
                {
                    if (coin.gameObject.activeSelf)
                        score = UpdateCoin(data, coin, score);
                }

                if (lastSpawnTime <= 0)
                {
                    lastSpawnTime = data.coinsRate;
                    SpawnCoin();
                }
            }

            DEBUG_FINISH = false;
            
            StopGame();
            OnLevelComplete?.Invoke(data);

            gameView.Hide();
            winView.Show();
            
            winScoreText.text = $"Score: {score:000}s";
        }

        public void StopGame()
        {
            _tokenSource?.Cancel();

            foreach (var coin in coins)
            {
                coin.gameObject.SetActive(false);
            }
        }

        private void UpdateShip(LevelData data)
        {
            var offset = 0f;
            if (leftButton.IsDown) offset = -data.shipSpeed * Time.deltaTime;
            if (rightButton.IsDown) offset = data.shipSpeed * Time.deltaTime;
            ship.anchoredPosition = new Vector2(
                Mathf.Clamp(ship.anchoredPosition.x + offset, -300, 300),
                ship.anchoredPosition.y);
        }

        private int UpdateCoin(LevelData data, RectTransform coin, int score)
        {
            coin.transform.position += Vector3.down * data.coinsSpeed * Time.deltaTime;

            if (coin.anchoredPosition.y < -2500)
            {
                coin.gameObject.SetActive(false);
            }

            if (Vector3.Distance(ship.transform.position, coin.transform.position) < data.collectionDistance)
            {
                score += data.coinScoreAddition;
                scoreText.text = $"Score: {score:000}s";

                coin.gameObject.SetActive(false);
                
                GameSound.I.PlayCoinSound();
            }

            return score;
        }

        private void SpawnCoin()
        {
            foreach (var coin in coins)
            {
                if (coin.gameObject.activeSelf == false)
                {
                    coin.gameObject.SetActive(true);
                    coin.anchoredPosition = new Vector2(Random.Range(-300, 300), 0);
                    return;
                }
            }
        }


        protected override void OnShowStart() =>
            UIManager.I.GetWindow<BackgroundScreen>().EnableBlur();

        protected override void OnHideStart() =>
            UIManager.I.GetWindow<BackgroundScreen>().DisableBlur();
    }
}