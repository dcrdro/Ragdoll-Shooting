using System;
using UnityEngine;

public abstract class GameOverDisabler : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;

    private void OnEnable() => gameOverManager.OnGameOver += OnGameOver;
    private void OnDisable() => gameOverManager.OnGameOver -= OnGameOver;

    protected abstract void OnGameOver();
}
