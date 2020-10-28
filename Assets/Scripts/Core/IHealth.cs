using System;
using UnityEngine;

public interface IHealth : IDamagable, IHealable
{
    float HealthAmount { get; }
    float MaxHealthAmount { get; }
    bool IsDead { get; }

    event Action<DeathArgs> OnDied;
}
