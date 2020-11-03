using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private Health health;
    
    public event Action<IDamagable, DamageArgs> DamageTaken;
    
    public void TakeDamage(DamageArgs args)
    {
        DamageArgs pointDamageArgs = new DamageArgs(args.Origin, args.Dealer, 1);
        health.TakeDamage(pointDamageArgs);
        DamageTaken?.Invoke(this, pointDamageArgs);
    }
}
