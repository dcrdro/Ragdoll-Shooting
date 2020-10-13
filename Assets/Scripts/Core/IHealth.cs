using System;

public interface IHealth : IDamagable
{
    float HealthAmount { get; }
    float MaxHealthAmount { get; }
    bool IsDead { get; }

    event Action OnDied;
}
