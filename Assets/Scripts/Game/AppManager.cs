using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public event Action OnPauseGame;
    public event Action OnResumeGame;
    
    public void RestartGame()
    {
        UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        OnPauseGame?.Invoke();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        OnResumeGame?.Invoke();
    }
}
