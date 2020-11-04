using System;
using System.Collections.Generic;
using Core.Fighting;
using Core.Fighting.Args;
using Core.General;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class ExplosionDamager : MonoBehaviour, IMultiTargetDamager, IOriginDerived
    {
        [SerializeField] private float damage;

        public GameObject Origin { get; set; }
    
        public event Action<IEnumerable<IDamagable>> Damaged;
    
        public void Damage(IEnumerable<IDamagable> damagables)
        {
            DamageArgs damageArgs = new DamageArgs(Origin, gameObject, damage);
            foreach (var damagable in damagables)
            {
                damagable.TakeDamage(damageArgs);
            }
            Damaged?.Invoke(damagables);
        }
    }
}
