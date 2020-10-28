using System;
using UnityEngine;

public class HitReceiver : MonoBehaviour, IDamagable, IForceable
{
    [SerializeField] private HitboxID hitboxID;

    public HitboxID HitboxID => hitboxID;

    public event Action<IDamagable, DamageArgs> OnDamageTaken;
    public event Action<IForceable, Vector3> OnForceApplied;

    public void TakeDamage(DamageArgs args) => OnDamageTaken?.Invoke(this, args);

    public void ApplyForce(Vector3 force) => OnForceApplied?.Invoke(this, force);
    public void Stop() { }
}
