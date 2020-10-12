using System;
using UnityEngine;

public class HitReceiver : MonoBehaviour, IDamagable
{
    [SerializeField] private HitboxID hitboxID;

    public HitboxID HitboxID => hitboxID;

    public event Action<IDamagable, float> OnDamageTaken;
    
    public void TakeDamage(float damage) => OnDamageTaken?.Invoke(this, damage);
}
