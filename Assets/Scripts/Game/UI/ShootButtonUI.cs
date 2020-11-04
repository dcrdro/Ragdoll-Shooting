using Core.UI;
using Game.Fighting.Shooting;
using UnityEngine;

namespace Game.UI
{
    public class ShootButtonUI : UIBase
    {
        [SerializeField] private Weaponer weaponer;
    
        // UI Event
        public void OnShoot() => weaponer.ApplyWeapon();
    }
}
