using Game.Fighting.Handlers;
using UnityEngine;

namespace Game.Management
{
    public class BonusesSpawnerDisabler : GameOverDisabler
    {
        [SerializeField] private BonusesSpawner spawner;

        protected override void OnGameOver() => spawner.enabled = false;
    }
}
