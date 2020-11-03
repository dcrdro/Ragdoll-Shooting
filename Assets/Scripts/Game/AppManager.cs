using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public event Action GamePaused;
    public event Action GameResumed;
    
    public void RestartGame()
    {
        UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GamePaused?.Invoke();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        GameResumed?.Invoke();
    }
}
