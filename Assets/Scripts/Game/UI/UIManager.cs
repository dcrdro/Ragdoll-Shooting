using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable() => gameOverManager.OnGameOver += OnGameOver;

    private void OnDisable() => gameOverManager.OnGameOver -= OnGameOver;

    private void OnGameOver() => StartCoroutine(WaitForShowGameOver());

    private IEnumerator WaitForShowGameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
    }
}
