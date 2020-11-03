using System;
using UnityEngine;

public class ControlDisabler : GameOverDisabler
{
    [SerializeField] private FighterControllerBase fighterController;

    protected override void OnGameOver() => fighterController.enabled = false;
}
