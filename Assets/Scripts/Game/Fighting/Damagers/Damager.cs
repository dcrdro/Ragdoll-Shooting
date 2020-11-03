using System;
using Core.Fighting;
using Core.Fighting.Args;
using Core.General;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class Damager : MonoBehaviour, IDamager, IOriginDerived
    {
        [SerializeField] private float damage;
    
        public event Action<IDamagable> Damaged;
    
        public GameObject Origin { get; set; }

        public void Damage(IDamagable damagable)
        {
            damagable.TakeDamage(new DamageArgs(Origin, gameObject, damage));
            Damaged?.Invoke(damagable);
        }
    }
}
