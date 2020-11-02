using UnityEngine;

public class ShootButtonUI : UIBase
{
    [SerializeField] private Weaponer weaponer;
    
    // UI Event
    public void OnShoot() => weaponer.ApplyWeapon();
}
