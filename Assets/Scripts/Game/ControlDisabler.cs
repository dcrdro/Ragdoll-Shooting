using System;
using UnityEngine;

public class ControlDisabler : MonoBehaviour
{
    [SerializeField] private UnitControllerBase unitController;
    [SerializeField] private GameOverManager gameOverManager;

    private void OnEnable() => gameOverManager.OnGameOver += OnGameOver;
    private void OnDisable() => gameOverManager.OnGameOver -= OnGameOver;

    private void OnGameOver() => unitController.enabled = false;
}
