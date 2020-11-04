using UnityEngine;

namespace Game.Control
{
    public class PlayerKeyboardController : FighterControllerBase
    {
        [SerializeField] private KeyCode shootKey;
        [SerializeField] private KeyCode jumpKey;

        public override void Init()
        {
        }

        public override void UpdateControl()
        {
            if (Input.GetKeyDown(shootKey))
            {
                weaponer.ApplyWeapon();
            }

            if (Input.GetKeyDown(jumpKey))
            {
                jumper.TryJump();
            }
        }
    }
}
