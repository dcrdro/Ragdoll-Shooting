using UnityEngine;

public class PlayerKeyboardController : UnitControllerBase
{
    [SerializeField] private KeyCode shootKey;
    [SerializeField] private KeyCode jumpKey;
    
    protected override void Init()
    {
    }

    protected override void UpdateControl()
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
