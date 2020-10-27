using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private Health health;
    
    public event Action<IDamagable, float> OnDamageTaken;
    
    public void TakeDamage(float damage)
    {
        health.TakeDamage(1);
        OnDamageTaken?.Invoke(this, 1);
    }
}
