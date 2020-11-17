using System;
using Core.General;
using UnityEngine;

namespace Game.Fighting.Shooting
{
    public class Weaponer : MonoBehaviour, IOriginDerived
    {
        [SerializeField] private WeaponBase weapon;

        public WeaponBase Weapon => weapon;
        
        public GameObject Origin { get; set; }

        public event Action WeaponApplied;

        private void Start()
        {
            Weapon.Origin = Origin;
        }

        [ContextMenu("ApplyWeapon test")]
        public void ApplyWeapon()
        {
            Weapon.Shoot();
            WeaponApplied?.Invoke();
        }
    }
}
