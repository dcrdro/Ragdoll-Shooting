using System.Collections;
using Game.Management;
using UnityEngine;

namespace Game.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private AppManager appManager;
        [SerializeField] private GameOverManager gameOverManager;
    
        [Header("Panels")]
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject pausePanel;

        private void OnEnable()
        {
            gameOverManager.DidGameOver += OnGameOver;
            appManager.GamePaused += OnGamePaused;
            appManager.GameResumed += OnGameResumed;
        }

        private void OnDisable()
        {
            gameOverManager.DidGameOver -= OnGameOver;
            appManager.GamePaused -= OnGamePaused;
            appManager.GameResumed -= OnGameResumed;
        }

        private void OnGameOver() => StartCoroutine(WaitForShowGameOver());

        private IEnumerator WaitForShowGameOver()
        {
            yield return new WaitForSeconds(1f);
            gameOverPanel.SetActive(true);
        }
    
        private void OnGamePaused() => pausePanel.SetActive(true);
        private void OnGameResumed() => pausePanel.SetActive(false);
    }
}
