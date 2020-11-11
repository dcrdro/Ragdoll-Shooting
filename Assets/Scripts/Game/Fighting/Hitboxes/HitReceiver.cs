using System;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Fighting.Hitboxes
{
    public class HitReceiver : MonoBehaviour, IDamagable, IForceable
    {
        [SerializeField] private HitboxID hitboxID;

        public HitboxID HitboxID => hitboxID;

        public event Action<IDamagable, DamageArgs> DamageTaken;
        public event Action<IForceable, ForceArgs> ForceApplied;

        public void TakeDamage(DamageArgs args) => DamageTaken?.Invoke(this, args);

        public void ApplyForce(ForceArgs args) => ForceApplied?.Invoke(this, args);
        public void Stop() { }
    }
}
