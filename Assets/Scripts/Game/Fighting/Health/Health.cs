using System;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Fighting.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private float healthMax;

        public float HealthAmount { get; private set; }
        public float MaxHealthAmount => healthMax;

        public bool IsDead => HealthAmount <= 0;

        public event Action<IDamagable, DamageArgs> DamageTaken;
        public event Action<IHealable, HealArgs> HealTaken;
        public event Action<DeathArgs> Died;

        private void Awake()
        {
            HealthAmount = healthMax;
        }

        public void TakeDamage(DamageArgs args)
        {
            UpdateHealth(args.Origin, args.Dealer, -args.Damage);
            DamageTaken?.Invoke(this, args);
        }
    
        public void TakeHeal(HealArgs args)
        {
            UpdateHealth(args.Origin, args.Dealer, +args.Heal);
            HealTaken?.Invoke(this, args);
        }

        private void UpdateHealth(in GameObject origin, in GameObject dealer, in float amount)
        {
            HealthAmount += amount;
            HealthAmount = Mathf.Clamp(HealthAmount, 0, healthMax);

            if (HealthAmount <= 0)
            {
                Died?.Invoke(new DeathArgs(origin, dealer));
            }
        }
    }
}
