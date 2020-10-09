using System;

public interface IHealth
{
    float HealthAmount { get; }
    float MaxHealthAmount { get; }
    bool IsDead { get; }
    void UpdateHealth(float amount);

    event Action OnHealthUpdated;
    event Action OnDied;
}
