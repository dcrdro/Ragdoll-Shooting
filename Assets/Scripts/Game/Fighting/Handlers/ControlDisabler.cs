using Game.Control;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class ControlDisabler : GameOverDisabler
    {
        [SerializeField] private FighterControllerBase fighterController;

        protected override void OnGameOver() => fighterController.enabled = false;
    }
}
