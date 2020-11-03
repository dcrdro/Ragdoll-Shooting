using System;
using System.Collections.Generic;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class ExplosionDamager : MonoBehaviour, IMultiTargetDamager
    {
        [SerializeField] private float damage;

        private GameObject explosionOrigin;
        private GameObject explosionSource;
    
        public event Action<IEnumerable<IDamagable>> Damaged;

        public void Init(GameObject origin, GameObject source)
        {
            explosionOrigin = origin;
            explosionSource = source;
        }
    
        public void Damage(IEnumerable<IDamagable> damagables)
        {
            DamageArgs damageArgs = new DamageArgs(explosionOrigin, explosionSource, damage);
            foreach (var damagable in damagables)
            {
                damagable.TakeDamage(damageArgs);
            }
            Damaged?.Invoke(damagables);
        }
    }
}
