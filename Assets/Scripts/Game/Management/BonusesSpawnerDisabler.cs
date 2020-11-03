using UnityEngine;

public class BonusesSpawnerDisabler : GameOverDisabler
{
    [SerializeField] private BonusesSpawner spawner;

    protected override void OnGameOver() => spawner.enabled = false;
}
