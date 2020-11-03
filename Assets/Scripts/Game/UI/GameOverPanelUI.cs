using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelUI : UIBase
{
    [SerializeField] private AppManager appManager;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private FighterConfigMapper fighterConfigMapper;
    [SerializeField] private Text winnerText;

    private void OnEnable()
    {
        string playerName = fighterConfigMapper[gameOverManager.WinnerID].Name;
        winnerText.text = $"{playerName} won!";
    }

    // UI Event
    public void OnRestart() => appManager.RestartGame();
}
