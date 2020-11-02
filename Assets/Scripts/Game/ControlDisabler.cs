using System;
using UnityEngine;

public class ControlDisabler : GameOverDisabler
{
    [SerializeField] private UnitControllerBase unitController;

    protected override void OnGameOver() => unitController.enabled = false;
}
