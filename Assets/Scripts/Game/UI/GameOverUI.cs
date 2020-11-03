using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : UIBase
{
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private FighterConfigMapper fighterConfigMapper;
    [SerializeField] private Text winnerText;

    private void OnEnable()
    {
        string playerName = fighterConfigMapper[gameOverManager.WinnerID].Name;
        winnerText.text = $"{playerName} won!";
    }
}
