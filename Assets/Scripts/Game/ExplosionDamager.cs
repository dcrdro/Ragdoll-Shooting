using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamager : MonoBehaviour, IMultiTargetDamager
{
    [SerializeField] private float damage;

    private GameObject explosionOrigin;
    private GameObject explosionSource;
    
    public event Action<IEnumerable<IDamagable>> OnDamaged;

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
        OnDamaged?.Invoke(damagables);
    }
}
