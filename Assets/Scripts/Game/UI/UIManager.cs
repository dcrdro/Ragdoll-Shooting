using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private AppManager appManager;
    [SerializeField] private GameOverManager gameOverManager;
    
    [Header("Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    private void OnEnable()
    {
        gameOverManager.OnGameOver += OnGameOver;
        appManager.OnPauseGame += OnPauseGame;
        appManager.OnResumeGame += OnResumeGame;
    }

    private void OnDisable()
    {
        gameOverManager.OnGameOver -= OnGameOver;
        appManager.OnPauseGame -= OnPauseGame;
        appManager.OnResumeGame -= OnResumeGame;
    }

    private void OnGameOver() => StartCoroutine(WaitForShowGameOver());

    private IEnumerator WaitForShowGameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
    }
    
    private void OnPauseGame() => pausePanel.SetActive(true);
    private void OnResumeGame() => pausePanel.SetActive(false);
}
