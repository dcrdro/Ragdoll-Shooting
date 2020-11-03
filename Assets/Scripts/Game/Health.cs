using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float healthMax;

    public float HealthAmount { get; private set; }
    public float MaxHealthAmount => healthMax;

    public bool IsDead => HealthAmount <= 0;

    public event Action<IDamagable, DamageArgs> OnDamageTaken;
    public event Action<IHealable, HealArgs> OnHealTaken;
    public event Action<DeathArgs> OnDied;

    private void Awake()
    {
        HealthAmount = healthMax;
    }

    public void TakeDamage(DamageArgs args)
    {
        UpdateHealth(args.Origin, args.Dealer, -args.Damage);
        OnDamageTaken?.Invoke(this, args);
    }
    
    public void TakeHeal(HealArgs args)
    {
        UpdateHealth(args.Origin, args.Dealer, +args.Heal);
        OnHealTaken?.Invoke(this, args);
    }

    private void UpdateHealth(in GameObject origin, in GameObject dealer, in float amount)
    {
        HealthAmount += amount;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, healthMax);

        print("update health: " + HealthAmount);
        if (HealthAmount <= 0)
        {
            OnDied?.Invoke(new DeathArgs(origin, dealer));
        }
    }
}
