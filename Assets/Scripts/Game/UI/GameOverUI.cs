using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : UIBase
{
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private Text winnerText;

    private void OnEnable() => winnerText.text = $"{gameOverManager.WinnerID} player won!";
}
