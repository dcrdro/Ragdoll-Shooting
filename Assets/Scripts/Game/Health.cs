using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float healthMax;

    public float HealthAmount { get; private set; }
    public float MaxHealthAmount => healthMax;

    public bool IsDead => HealthAmount <= 0;

    public event Action OnHealthUpdated;
    public event Action OnDied;

    private void Awake()
    {
        HealthAmount = healthMax;
    }

    public void UpdateHealth(float amount)
    {
        HealthAmount += amount;
        HealthAmount = Mathf.Clamp(HealthAmount, 0, healthMax);

        OnHealthUpdated?.Invoke();
        print("health: " + HealthAmount);
        if (HealthAmount <= 0)
        {
            OnDied?.Invoke();
        }
    }
}
