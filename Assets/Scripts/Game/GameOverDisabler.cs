using System;
using UnityEngine;

public abstract class GameOverDisabler : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;

    private void OnEnable() => gameOverManager.DidGameOver += OnGameOver;
    private void OnDisable() => gameOverManager.DidGameOver -= OnGameOver;

    protected abstract void OnGameOver();
}
