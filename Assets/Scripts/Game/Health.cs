using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float healthMax;

    public float HealthAmount { get; private set; }
    public float MaxHealthAmount => healthMax;

    public bool IsDead => HealthAmount <= 0;

    public event Action<IDamagable, float> OnDamageTaken;
    public event Action<IHealable, float> OnHealTaken;
    public event Action OnDied;

    private void Awake()
    {
        HealthAmount = healthMax;
    }

    public void TakeDamage(float damage)
    {
        HealthAmount -= damage;
    }
    
    public void TakeHeal(float heal)
    {
        UpdateHealth(+heal);
        OnHealTaken?.Invoke(this, heal);
    }

    private void UpdateHealth(float amount)
    {
        HealthAmount += amount;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, healthMax);

        OnDamageTaken?.Invoke(this, damage);
        print("health: " + HealthAmount);
        if (HealthAmount <= 0)
        {
            OnDied?.Invoke();
        }
    }
}
