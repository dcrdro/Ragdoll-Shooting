using System;
using UnityEngine;

public class HitReceiver : MonoBehaviour, IDamagable, IForceable
{
    [SerializeField] private HitboxID hitboxID;

    public HitboxID HitboxID => hitboxID;

    public event Action<IDamagable, float> OnDamageTaken;
    public event Action<IForceable, Vector3> OnForceApplied;

    public void TakeDamage(float damage) => OnDamageTaken?.Invoke(this, damage);

    public void ApplyForce(Vector3 force) => OnForceApplied?.Invoke(this, force);
    public void Stop() { }
}
