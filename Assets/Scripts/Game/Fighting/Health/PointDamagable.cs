using System;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Fighting.Health
{
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
}
