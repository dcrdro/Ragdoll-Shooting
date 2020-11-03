﻿using System;
using UnityEngine;

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
